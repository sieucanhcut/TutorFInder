using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;
using Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services;
using Microsoft.AspNetCore.Identity.Data;

namespace FTSA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly TutorWebContext _context;
        private readonly ICustomEmailService _emailService;
        private readonly IUserService _userService;

        public AccountController(TutorWebContext context, ICustomEmailService emailService, IUserService userService)
        {
            _context = context;
            _emailService = emailService;
            _userService = userService;
        }

        private async Task<Guid?> GetRoleIdByName(string roleName)
        {
            var role = await _context.Roles.FirstOrDefaultAsync(r => r.RoleName == roleName);
            return role?.RoleId;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] SignUpModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingUserByEmail = await _userService.GetUserByEmailAsync(model.Email);
            if (existingUserByEmail != null)
            {
                return BadRequest(new { message = "Email đã được đăng ký" });
            }

            var existingUserByPhone = await _context.Users
                .FirstOrDefaultAsync(u => u.PhoneNumber == model.PhoneNumber);
            if (existingUserByPhone != null)
            {
                return BadRequest(new { errors = new { PhoneNumber = new[] { "Số điện thoại đã được đăng ký" } } });
            }

            var existingUserByCitizenId = await _context.Users
                .FirstOrDefaultAsync(u => u.CitizenId == model.CitizenId);
            if (existingUserByCitizenId != null)
            {
                return BadRequest(new { errors = new { CitizenId = new[] { "Căn cước công dân đã được đăng ký" } } });
            }

            var roleId = await GetRoleIdByName(model.Role);
            if (roleId == null)
            {
                return BadRequest(new { message = "Invalid role selected" });
            }

            var newUser = new User
            {
                UserId = Guid.NewGuid(),
                UserName = model.UserName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Password = BCrypt.Net.BCrypt.HashPassword(model.Password), // Use BCrypt for hashing
                Gender = model.Gender,
                DateOfBirth = model.DateOfBirth,
                PlaceOfWork = model.PlaceOfWork,
                CitizenId = model.CitizenId,
                RoleId = roleId.Value,
                RegistrationDate = DateTime.UtcNow,
                IsEmailConfirmed = false,
            };

            await _userService.CreateUserAsync(newUser);
            await _emailService.SendConfirmationEmail(newUser.Email, newUser.UserId, Request.Scheme, Request.Host.ToString());

            return Ok(new { message = "Registration successful! Please check your email for confirmation." });
        }

        [HttpGet("confirm-email")]
        public async Task<IActionResult> ConfirmEmail(Guid userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId);
            if (user == null)
            {
                return NotFound(new { message = "Email không tồn tại." });
            }

            if (user.IsEmailConfirmed)
            {
                return BadRequest(new { message = "Email đã được xác nhận trước đó." });
            }

            user.IsEmailConfirmed = true;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            // Redirect về trang đăng ký với thông báo thành công
            return Redirect($"http://localhost:5173/register?success=true");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(SignInModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _context.Users
                    .Include(u => u.Role) 
                    .FirstOrDefaultAsync(u => u.Email == model.Email);

                // Check if user exists
                if (user != null)
                {
                    // Check if user is blocked
                    if (user.Role?.RoleName == "Blocked")
                    {
                        return BadRequest(new { message = "Tài khoản của bạn đã bị khoá." }); 
                    }

                    // Verify password
                    var passwordMatches = BCrypt.Net.BCrypt.Verify(model.Password, user.Password);
                    if (passwordMatches)
                    {
                        var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.RoleId.ToString())
                };

                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var authProperties = new AuthenticationProperties { };

                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                            new ClaimsPrincipal(claimsIdentity), authProperties);

                        return Ok(new { message = "Login successful" });
                    }
                    else
                    {
                        return Unauthorized(new { message = "Invalid password." });
                    }
                }
                else
                {
                    return NotFound(new { message = "User not found." });
                }
            }
            return BadRequest(ModelState);
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequest request)
        {
            // Kiểm tra xem email có được nhập không
            if (string.IsNullOrEmpty(request.Email))
            {
                return BadRequest(new { message = "Vui lòng nhập email." });
            }

            // Tìm người dùng trong cơ sở dữ liệu
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
            if (user == null)
            {
                return BadRequest(new { message = "Email không tồn tại." });
            }

            // Tạo token cho việc reset mật khẩu
            var token = Guid.NewGuid().ToString();
            user.ResetToken = token; // Lưu token vào cơ sở dữ liệu
            user.ResetTokenExpiry = DateTime.UtcNow.AddHours(1); // Token hết hạn sau 1 giờ
            await _context.SaveChangesAsync();

            // Tạo link reset password
            var resetLink = $"http://localhost:5173/reset-password?token={token}&email={user.Email}";

            // Soạn nội dung email
            string subject = "Yêu cầu thay đổi mật khẩu";
            string body = $"Nhấn vào đường link để thay đổi mật khẩu của bạn: <a href='{resetLink}'>Reset Password</a>";

            // Gửi email cho người dùng
            await SendEmail(user.Email, subject, body);

            return Ok(new { message = "Email reset password đã được gửi, vui lòng kiểm tra hộp thư của bạn." });
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
        {
            // Tìm người dùng với email và token được cung cấp
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email && u.ResetToken == request.Token);

            // Kiểm tra token có hợp lệ không và có hết hạn không
            if (user == null || user.ResetTokenExpiry < DateTime.UtcNow)
            {
                return BadRequest(new { message = "Token không hợp lệ hoặc đã hết hạn." });
            }

            // Mã hóa mật khẩu mới
            user.Password = BCrypt.Net.BCrypt.HashPassword(request.NewPassword);
            user.ResetToken = null; 
            user.ResetTokenExpiry = null; 
            await _context.SaveChangesAsync();

            return Ok(new { message = "Mật khẩu đã được đổi thành công." });
        }

        private async Task SendEmail(string email, string subject, string body)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("taiinu0126@gmail.com"); // Thay thế bằng email của bạn
                mail.To.Add(email);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential("taiinu0126@gmail.com", "sdgu ypqh ybmi cmqs"); // Thay thế bằng email và mật khẩu của bạn
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(mail);
                }
            }
        }

    }
}

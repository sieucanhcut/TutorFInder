using DataAccess.dbContext_Access;
using DataObject;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Net;

namespace FSTAWebApplication.Controllers
{
    public class AccountController : Controller
    {
        private readonly TutorWebContext _context;

        public AccountController(TutorWebContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(SignInModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _context.Users
                    .FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);

                if (user != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.Role, user.RoleId.ToString()),
                        new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString())
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties { };

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity), authProperties);

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult SelectRole()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SelectRole(string role)
        {
            if (role == "Student")
            {
                return RedirectToAction("Register", new { userRole = "Student" });
            }
            else if (role == "Tutor")
            {
                return RedirectToAction("Register", new { userRole = "Tutor" });
            }

            return View();
        }

        [HttpGet]
        public IActionResult Register(string userRole)
        {
            ViewData["UserRole"] = userRole;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(SignUpModel model)
        {
            if (ModelState.IsValid)
            {
                var role = await _context.Roles.FirstOrDefaultAsync(r => r.RoleName == model.Role);
                if (role == null)
                {
                    ModelState.AddModelError("", "Invalid role selected.");
                    return View(model);
                }

                var user = new User
                {
                    UserId = Guid.NewGuid(),
                    UserName = model.UserName,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    Password = model.Password, 
                    RoleId = role.RoleId,
                    Gender = model.Gender,
                    PlaceOfWork = model.PlaceOfWork,
                    DateOfBirth = model.DateOfBirth,
                    CitizenId = model.CitizenId,
                    IsEmailConfirmed = false, 
                    RegistrationDate = DateTime.UtcNow 

                };
                try
                {
                    _context.Users.Add(user);
                    await _context.SaveChangesAsync();

                    await SendConfirmationEmail(user.Email, user.UserId);

                    ViewData["ShowRegisterConfirmation"] = true;
                    return View(model);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Error while saving user: {ex.Message}");
                    return View(model);
                }
            }

            return View(model);
        }

        // phương thức gửi mail xác nhận
        private async Task SendConfirmationEmail(string email, Guid userId)
        {
            string confirmationLink = Url.Action("ConfirmEmail", "Account", new { userId = userId }, Request.Scheme);
            string subject = "Confirm your email";
            string body = $"Please confirm your email by clicking this link: <a href='{confirmationLink}'>Confirm Email</a>";

            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("taiinu0126@gmail.com");
                mail.To.Add(email);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential("taiinu0126@gmail.com", "sdgu ypqh ybmi cmqs"); // Use your email and password
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(mail);
                }
            }
        }

        [HttpGet]
        public IActionResult ConfirmEmail(Guid userId)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserId == userId);
            if (user != null)
            {
                user.IsEmailConfirmed = true;
                _context.SaveChanges();
                ViewData["ShowEmailConfirmed"] = true;
                return View("Register");
            }
            return RedirectToAction("Register");
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                ModelState.AddModelError("", "Please enter your email.");
                return View();
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
            {
                ModelState.AddModelError("", "Email not found.");
                return View();
            }

            var token = Guid.NewGuid().ToString();

            // gửi reset link mail
            var resetLink = Url.Action("ResetPassword", "Account", new { token, email = user.Email }, Request.Scheme);
            string subject = "Password Reset Request";
            string body = $"Click here to reset your password: <a href='{resetLink}'>Reset Password</a>";

            await SendEmail(user.Email, subject, body);

            user.ResetToken = token;
            user.ResetTokenExpiry = DateTime.UtcNow.AddHours(1); 
            await _context.SaveChangesAsync();

            return RedirectToAction("ForgotPasswordConfirmation");
        }

        [HttpGet]
        public IActionResult ResetPassword(string token, string email)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email && u.ResetToken == token);
            if (user == null || user.ResetTokenExpiry < DateTime.UtcNow)
            {
                ModelState.AddModelError("", "Invalid or expired token.");
                return RedirectToAction("ForgotPassword");
            }

            ViewBag.Email = email;
            ViewBag.Token = token;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(string email, string token, string newPassword)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email && u.ResetToken == token);

            if (user == null || user.ResetTokenExpiry < DateTime.UtcNow)
            {
                ModelState.AddModelError("", "Invalid or expired token.");
                return View();
            }

            user.Password = newPassword;
            user.ResetToken = null;
            user.ResetTokenExpiry = null;
            await _context.SaveChangesAsync();

            ViewData["ShowPasswordResetSuccess"] = true; 
            ViewBag.Email = email;
            ViewBag.Token = token;
            return View(); 
        }




        private async Task SendEmail(string email, string subject, string body)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("taiinu0126@gmail.com");
                mail.To.Add(email);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential("taiinu0126@gmail.com", "sdgu ypqh ybmi cmqs");
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(mail);
                }
            }
        }
        [HttpGet]
        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }


    }
}

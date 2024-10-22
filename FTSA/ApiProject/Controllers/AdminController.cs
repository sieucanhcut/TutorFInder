using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Controllers
{
    [Route("api/admin")]
    [ApiController]

    public class AdminController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly TutorWebContext _context;

        public AdminController(IUserRepository userRepository, TutorWebContext context)
        {
            _userRepository = userRepository;
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        // GET: api/admin/users
        [HttpGet("users")]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers(string searchTerm = null, Guid? roleId = null)
        {
            var users = await _userRepository.FindAllAsync();

            // Lọc theo searchTerm
            if (!string.IsNullOrEmpty(searchTerm))
            {
                users = users.Where(u => u.UserName.Contains(searchTerm) || u.Email.Contains(searchTerm)).ToList();
            }

            // Lọc theo roleId nếu được chỉ định
            if (roleId.HasValue)
            {
                users = users.Where(u => u.RoleId == roleId.Value).ToList();
            }

            return Ok(users);
        }

        [HttpPut("users/{userId}/block")]
        public async Task<IActionResult> BlockUser(Guid userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }

            user.RoleId = Guid.Parse("6425aec4-e6e1-4287-95f2-5ee8862429d4");
            await _userRepository.UpdateUserAsync(user);

            return NoContent();
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchUsers(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                var users = await _context.Users.ToListAsync();
                return Ok(users);
            }

            searchTerm = searchTerm.ToLower();
            DateTime? searchDate = null;
            if (DateTime.TryParse(searchTerm, out DateTime parsedDate))
            {
                searchDate = parsedDate;
            }

            var filteredUsers = await _context.Users
                .Where(u => (u.UserName.ToLower() ?? "").Contains(searchTerm) ||
                            (u.Email.ToLower() ?? "").Contains(searchTerm) ||
                            (u.PhoneNumber.ToLower() ?? "").Contains(searchTerm) ||
                            (searchDate.HasValue && u.RegistrationDate.Date == searchDate.Value.Date))
                .ToListAsync();

            return Ok(filteredUsers);
        }

        [HttpGet("statistics")]
        public IActionResult GetRegistrationStatistics(string period)
        {
            var currentDate = DateTime.Now;
            var startDate = currentDate;
            var endDate = currentDate;

            switch (period.ToLower())
            {
                case "day":
                    startDate = currentDate.Date;
                    endDate = currentDate.Date.AddDays(1);
                    break;
                case "month":
                    startDate = new DateTime(currentDate.Year, currentDate.Month, 1);
                    endDate = startDate.AddMonths(1);
                    break;
                case "year":
                    startDate = new DateTime(currentDate.Year, 1, 1);
                    endDate = startDate.AddYears(1);
                    break;
                default:
                    return BadRequest("Invalid period");
            }

            var registrations = _context.Users
                .Include(u => u.Role)
                .Where(u => u.RegistrationDate >= startDate && u.RegistrationDate < endDate)
                .GroupBy(u => new { u.RegistrationDate.Date, u.Role.RoleName })
                .Select(g => new
                {
                    Date = g.Key.Date,
                    Role = g.Key.RoleName,
                    Count = g.Count()
                })
                .OrderBy(r => r.Date)
                .ToList();

            var result = registrations.GroupBy(r => r.Date)
                .Select(g => new
                {
                    Date = g.Key,
                    StudentCount = g.Where(x => x.Role == "Student").Sum(x => x.Count),
                    TutorCount = g.Where(x => x.Role == "Tutor").Sum(x => x.Count)
                })
                .OrderBy(r => r.Date)
                .ToList();

            return Ok(result);
        }


    }
}

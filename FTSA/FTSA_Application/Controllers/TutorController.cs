using DataAccess.Repos;
using FSTAWebApplication.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace FTSA_Application.Controllers
{
    public class TutorController : Controller
    {
        private readonly ITutorRepository _tutorRepository;
        private readonly ILogger<TutorController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IUserRepository _userRepository;
        private readonly ILocationRepository _locationRepository;
        public TutorController(ILogger<TutorController> logger, 
            ITutorRepository tutorRepository, 
            IWebHostEnvironment webHostEnvironment, 
            IUserRepository userRepository,
            ILocationRepository locationRepository)
        {
            _logger = logger;
            _tutorRepository = tutorRepository;
            _webHostEnvironment = webHostEnvironment;
            _userRepository = userRepository;
            _locationRepository = locationRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userIdClaim == null)
            {
                return RedirectToAction("Login", "Account");
            }
            Guid userId = Guid.Parse(userIdClaim);

            var tutor = await _tutorRepository.GetTutorDetailsAsync(userId);

            if (tutor == null)
            {
                var user = await _userRepository.GetUserAsync(userId);
                if (user != null)
                {
                    ViewBag.UserId = userId;
                    ViewBag.UserName = user.UserName;
                    return View();
                }
                return RedirectToAction("Login", "Account");
            }
            return View(tutor);
        }
        [HttpGet]
        public async Task<IActionResult> ProfileAsync()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userIdClaim == null)
            {
                return RedirectToAction("Login", "Account");
            }
            Guid userId = Guid.Parse(userIdClaim);

            var user = await _userRepository.GetUserAsync(userId);

            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var locations = await _locationRepository.GetAllLocations();

            ViewBag.Locations = locations.Select(l => new SelectListItem
            {
                Value = l.LocationId.ToString(),
                Text = $"{l.District}, {l.CityOrProvince}"
            }).ToList();
            return View(user);
        }
        [HttpPost]
        public IActionResult Createa()
        {
            return View();
        }
    }
}

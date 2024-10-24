using Entities.Dto;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Implements;
using System.Linq.Expressions;
using System.Security.Claims;
using Services.Interfaces;

namespace ApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TutorDetailsController : ControllerBase
    {
        private readonly ITutorDetailsService _tutorDetailsService;

        public TutorDetailsController(ITutorDetailsService tutorDetailsService)
        {
            _tutorDetailsService = tutorDetailsService;
        }

        // GET: api/tutordetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RequestTutorDetails>>> GetAllTutors(bool trackChanges)
        {
            var tutors = await _tutorDetailsService.FindAllAsync(trackChanges);
            return Ok(tutors);
        }

        // GET: api/tutordetails/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<RequestTutorDetails>> GetTutorById(Guid id)
        {
            var tutor = await _tutorDetailsService.FindByIdAsync(id);

            if (tutor == null)
            {
                return NotFound();
            }

            return Ok(tutor);
        }

        // POST: api/tutordetails
        [HttpPost]
        public async Task<ActionResult> CreateTutor([FromBody] RequestTutorDetails request)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            request.TutorId = Guid.NewGuid();
            if (userIdClaim != null)
            {
                Guid userId = Guid.Parse(userIdClaim?.Value);
                request.UserId = userId;
            }
            await _tutorDetailsService.CreateAsync(request);
            return CreatedAtAction(nameof(GetTutorById), new { id = request.TutorId }, request);
        }

        // PUT: api/tutordetails/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTutor(Guid id, [FromBody] RequestTutorDetails request)
        {

            var result = await _tutorDetailsService.UpdateAsync(request, id);
            if (result == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/tutordetails/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTutor(Guid id)
        {
            var result = await _tutorDetailsService.DeleteAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // GET: api/tutordetails/search
        [HttpGet("search")]
        public async Task<ActionResult<List<RequestTutorDetails>>> SearchTutors([FromQuery] string keyword, bool trackChanges)
        {
            Expression<Func<RequestTutorDetails, bool>> expression = tutor =>
            tutor.Gender.Contains(keyword) ||
            tutor.UserName.Contains(keyword) ||
            tutor.City.Contains(keyword) ||
            tutor.District.Contains(keyword) ||
            tutor.Faculty.Contains(keyword) ||
            tutor.PlaceOfWork.Contains(keyword) ||
            tutor.TeachingAchievement.Contains(keyword) ||
            tutor.Transportation.Contains(keyword) ||
            tutor.AcademicSpecialty.Contains(keyword) ||
            tutor.Title.Contains(keyword) ||
            tutor.SelfIntroduction.Contains(keyword);

            var tutors = await _tutorDetailsService.SearchTutorsAsync(expression, trackChanges);
            return Ok(tutors);
        }
    }
}
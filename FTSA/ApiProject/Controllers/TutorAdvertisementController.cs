using Entities.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System.Linq.Expressions;

namespace ApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TutorAdvertisementController : ControllerBase
    {
        private readonly ITutorAdvertisementService _tutorAdvertisementService;
        private readonly ITutorDetailsService _tutorDetailsService;

        public TutorAdvertisementController(ITutorAdvertisementService tutorAdvertisementService, ITutorDetailsService tutorDetailsService)
        {
            _tutorAdvertisementService = tutorAdvertisementService;
            _tutorDetailsService = tutorDetailsService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RequestTutorAdvertisement request)
        {
            if (request == null)
            {
                return BadRequest("Invalid advertisement request.");
            }
            request.AdvertisementId = Guid.NewGuid();
            await _tutorAdvertisementService.CreateAsync(request);
            return CreatedAtAction(nameof(FindById), new { id = request.AdvertisementId }, request);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _tutorAdvertisementService.DeleteAsync(id);
            if (result == false)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] bool trackChanges = false)
        {
            var advertisements = await _tutorAdvertisementService.FindAllAsync(trackChanges);
            return Ok(advertisements);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(Guid id)
        {
            var advertisement = await _tutorAdvertisementService.FindByIdAsync(id);
            if (advertisement == null)
            {
                return NotFound();
            }
            return Ok(advertisement);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] RequestTutorAdvertisement request)
        {
            if (request == null)
            {
                return BadRequest("Invalid advertisement request.");
            }

            var result = await _tutorAdvertisementService.UpdateAsync(request, id);
            if (result == false)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string query, [FromQuery] bool trackChanges = false)
        {
            var expression = BuildSearchExpression(query);
            var results = await _tutorAdvertisementService.SearchTutorsAsync(expression, trackChanges);
            return Ok(results);
        }

        private Expression<Func<RequestTutorAdvertisement, bool>> BuildSearchExpression(string query)
        {
            return ad => ad.Description.Contains(query) ||
                  ad.Title.Contains(query) ||
                  ad.City.Contains(query) ||
                  ad.UserName.Contains(query);
        }
    }
}
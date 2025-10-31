using Application.DTOs.EvenDTOs;
using Application.Interfaces.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace chas_happenings.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventServices _EventServices;

        public EventController(IEventServices eventServices)
        {
            _EventServices = eventServices;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateEvent([FromBody] CreateEventDTO Event,[FromQuery] int userId)
        {
            if(await _EventServices.AddEventServicesAsync(Event, userId))
            {
                return Ok("event created");
                
            }
            return BadRequest("operation failed, could not create or save event");
        }

        [HttpDelete("delete/{eventId}")]
        public async Task<IActionResult> DeleteEvent(int eventId)
        {
            if(await _EventServices.DeleteEventsByIdServicesAsync(eventId))
            {
                return Ok("event deleted");
            }
            return BadRequest("operation failed, No updates were made to the event");
        }

        [HttpGet("getbyid/{eventId}")]
        public async Task<ActionResult<GetEventCalenderDisplayDTO>> GetByIdDisplayData(int eventId)
        {
            var eventData = _EventServices.GetEventByIdDisplayDataServicesAsync(eventId);

            return Ok(eventData);
        }

        [HttpGet("getbyid/extradata/{eventId}")]
        public async Task<ActionResult<GetEventWithExtraDataDTO>> GetByIdExtraData(int eventId)
        {
            var evenData = await _EventServices.GetEventByIdWithExtraDataServicesAsync(eventId);

            return Ok(evenData);
        }
        [HttpGet("getbytags/getbydaterange")]
        public async Task<ActionResult<List<GetEventCalenderDisplayDTO>>> GetByTagsAndDateRange([FromQuery] HashSet<string> eventTags, [FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var eventData = await _EventServices.GetEventsByCategoriesAndDateServicesAsync(eventTags, startDate, endDate);

            return Ok(endDate);
        }
        [HttpGet("getbydate")]
        public async Task<ActionResult<List<GetEventCalenderDisplayDTO>>> GetByDateRange([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var eventData = await _EventServices.GetEventsByDateTimeServicesAsync(startDate, endDate);

            return Ok(eventData);
        }
        [HttpGet("getbytype/getbydaterange")]
        public async Task<ActionResult<List<GetEventCalenderDisplayDTO>>> GetByTypeAndDateRange([FromQuery] HashSet<string> eventType,[FromQuery] DateTime startDate,[FromQuery] DateTime endDate)
        {
            var eventData = await _EventServices.GetEventsByTypeAndDateServicesAsync(eventType, startDate, endDate);

            return Ok(eventData);
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateEvent([FromBody] UpdateEventDTO dto)
        {
            if(await _EventServices.UpdateEventServicesAsync(dto))
            {
                return Ok("Event updated");
            }
            return BadRequest("Event failed to update, no changes were made to the database");
        }
    }
}

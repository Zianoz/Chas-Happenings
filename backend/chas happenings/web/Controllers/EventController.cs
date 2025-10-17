using Application.DTOs.EvenDTOs;
using Application.Interfaces.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost("Create")]
        public async Task<ActionResult<int>> CreateEvent(CreateEventDTO Event)
        {
            var eventId = await _EventServices.AddEventServicesAsync(Event);

            if(eventId==0||eventId==null)
            {
                return BadRequest("operation failed, could not create or save event");
            }
            return Ok(eventId);
        }
    }
}

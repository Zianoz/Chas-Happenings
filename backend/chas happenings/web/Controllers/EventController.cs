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

        [HttpPost("vreate")]
        public async Task<ActionResult<int>> CreateEvent(CreateEventDTO Event,int userId)
        {
            if(await _EventServices.AddEventServicesAsync(Event, userId))
            {
                return Ok("event created");
                
            }
            return BadRequest("operation failed, could not create or save event");
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<int>> DeleteEvent(int eventId)
        {
            if(await _EventServices.DeleteEventsByIdServicesAsync(eventId))
            {
                return Ok("event deleted");
            }
            return BadRequest("operation failed, No updates were made to the event");
        }

        public async Task<ActionResult<GetEventCalenderDisplayDTO>> GetByIdC(int eventId)
        {
            await _EventServices.GetEventByIdDisplayDataServicesAsync(eventId);
        }

        public async Task<ActionResult<int>> GetCalenderDisplayData(CreateEventDTO Event, int userId)
        {

        }

        public async Task<ActionResult<int>> GetWithExtraData(CreateEventDTO Event, int userId)
        {

        }

        public async Task<ActionResult<int>> GetByTags(CreateEventDTO Event, int userId)
        {

        }

        public async Task<ActionResult<int>> GetByDate(CreateEventDTO Event, int userId)
        {

        }

        public async Task<ActionResult<int>> GetByType(CreateEventDTO Event, int userId)
        {

        }

        public async Task<ActionResult<int>> UpdateEvent(CreateEventDTO Event, int userId)
        {

        }
    }
}

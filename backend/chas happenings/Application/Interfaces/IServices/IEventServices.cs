using Application.DTOs.EvenDTOs;
using Domain.Models;
using Domain.Models.ConectionTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IServices
{
    public interface IEventServices
    {
        Task<GetEventCalenderDisplayDTO> GetEventByIdDisplayDataServicesAsync(int eventId);
        Task<GetEventWithExtraDataDTO> GetEventByIdWithExtraDataServicesAsync(int eventId);
        Task<bool> DeleteEventsByIdServicesAsync(int EventId); // DONE
        Task<bool> AddEventServicesAsync(CreateEventDTO Event, int userId); // DONE
        Task<bool> UpdateEventServicesAsync(UpdateEventDTO eventDto); // DONE - revisit (update tags too?)

        Task<List<Event?>> GetEventsByDateTimeServicesAsync(DateTime startdate, DateTime endDate);
        Task<List<Event?>> GetEventsByCategoriesAndDateServicesAsync(HashSet<string> eventTags, DateTime startdate, DateTime endDate);
        Task<List<Event?>> GetEventsByTypeAndDateServicesAsync(HashSet<string> eventType, DateTime startdate, DateTime endDate);

    }
}

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
        Task<Event?> GetEventByIdDisplayDataServicesAsync(int eventId);
        Task<GetEventWithExtraDataDTO?> GetEventByIdWithExtraDataServicesAsync(int eventId);
        Task<bool> DeleteEventsByIdServicesAsync(int EventId); // DONE
        Task<int> AddEventServicesAsync(CreateEventDTO Event); // DONE - Neads logick for adding a Createror (user)
        Task<bool> UpdateEventServicesAsync(UpdateEventDTO eventDto); // DONE - revisit (update tags too?)

        Task<List<Event?>> GetEventsByDateTimeServicesAsync(DateTime startdate, DateTime endDate);
        Task<List<Event?>> GetEventsByCategoriesAndDateServicesAsync(HashSet<string> EventTags, DateTime startdate, DateTime endDate);
        Task<List<Event?>> GetEventsByTypeAndDateServicesAsync(HashSet<string> EventType, DateTime startdate, DateTime endDate);

    }
}

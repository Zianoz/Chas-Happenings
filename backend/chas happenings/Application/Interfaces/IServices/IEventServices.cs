using Application.DTOs.EvenDTOs;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IServices
{
    public interface IEventServices
    {
        Task<Event?> GetEventByIdServicesAsync(int EventId);
        Task<int> DeleteEventsByIdServicesAsync(int EventId);
        Task<int> AddEventServicesAsync(CreateEventDTO Event);
        Task<int> UpdateEventServicesAsync(Event Event);

        Task<List<Event?>> GetEventsByDateTimeServicesAsync(DateTime startdate, DateTime endDate);
        Task<List<Event?>> GetEventsByCategoriesAndDateServicesAsync(HashSet<string> EventTags, DateTime startdate, DateTime endDate);
        Task<List<Event?>> GetEventsByTypeAndDateServicesAsync(HashSet<string> EventType, DateTime startdate, DateTime endDate);

    }
}

using Domain.Enums;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Irepositories
{
    public interface IEventRepositories
    {

        // Standard CRUD Operationer för Databasobjektet Event
        Task<Event?> GetEventByIdRepoAsync(int EventId);
        Task<int> DeleteEventsByIdRepoAsync(int EventId);
        Task<int> AddEventRepoAsync(Event Event);
        Task<int> UpdateEventRepoAsync(Event Event);

        // Operationer gör att hämta data inom en viss tidspan och med filter för tags och typ av event 
        Task<List<Event?>> GetEventsByDateTimeRepoAsync(DateTime startdate, DateTime endDate);
        Task<List<Event?>> GetEventsByCategoriesAndDateRepoAsync(HashSet<string> EventTags, DateTime startdate, DateTime endDate);
        Task<List<Event?>> GetEventsByTypeAndDateRepoAsync(EventType EventType, DateTime startdate, DateTime endDate);

        // Admin Endpoints  
        Task<List<Event?>> GetAllEventsRepoAsync();
        Task<List<Event?>> GetEventsByCategoriesRepoAsync(HashSet<string> EventTags);
        Task<List<Event?>> GetEventsWithDataByDateTimeRepoAsync(DateTime startdate, DateTime endDate);


        // hämta events via users egna settings
        // hämta events för ett specifikt datum- ETT SPECIFIKT - datum
        // Deleta flera events samtidigt från en lista med event id's              (för administratörer)
    }
}

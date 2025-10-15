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
        Task<List<Event?>> GetEventsByTypeAndDateRepoAsync(HashSet<string> EventType, DateTime startdate, DateTime endDate);

        // Operationer för Endpoints kring att hämta ALLA events baserat på en eller flera filter
        // tror vi kan vänta med att implementera dessa då det bara är administratören som kommer
        // använda dessa operationer     
        Task<List<Event?>> GetAllEventsRepoAsync();
        Task<List<Event?>> GetEventsByCategoriesRepoAsync(HashSet<string> EventTags);
        Task<List<Event?>> GetEventsWithDataByDateTimeRepoAsync(DateTime startdate, DateTime endDate);
        //------------------------------------------------------------------------------------------- 


        // Hämta events som händer inom en viss tidsspan     (för kalendern, veckor månader etc).
        // Hämta events basert på tags inom en viss tidspan  (för kalendern, veckor månader etc).
        // hämta events Efter Type                           (för att hämta events baserade på settings)
        // hämta events via users egna settings
        // hämta ett event för - ETT SPECIFIKT - datum
        // Deleta flera events samtidigt från en lista med event id's              (för administratörer)


    }
}

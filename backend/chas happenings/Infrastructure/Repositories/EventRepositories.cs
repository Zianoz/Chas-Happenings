using Domain.Models;
using Infrastructure.Data;
using Application.Interfaces.Irepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Infrastructure.Repositories
{
    public class EventRepositories : IEventRepositories
    {
        private readonly ChasHappeningsDbContext _context;

        public EventRepositories(ChasHappeningsDbContext context)
        {
            _context = context;
        }

        public async Task<List<Event?>> GetAllEventsRepoAsync()
        {
            var allEvents = await _context.Events.Include(e => e.Interactions).ThenInclude(u => u.User).Include(e => e.Comments).Include(e => e.Tags).ToListAsync();
            return allEvents;
        
        }

        public async Task<Event?> GetEventByIdRepoAsync(int EventId)
        {
            var Event = await _context.Events.Include(e => e.Interactions).ThenInclude(u => u.User).Include(e => e.Comments).Include(e => e.Tags).FirstOrDefaultAsync(e => e.Id == EventId);
            return Event;
        
        }

        public async Task<List<Event?>> GetEventsByCategoriesRepoAsync(HashSet<string> EventTags)
        {
            var eventsBytag = await _context.Events.Include(e => e.Tags).Where(e => e.Tags.Any(t => EventTags.Contains(t.TagName))).ToListAsync();
            return eventsBytag;
        }

        public async Task<int> DeleteEventsByIdRepoAsync(int EventId)
        {
            var results= await _context.Events.Where(e=>e.Id==EventId).ExecuteDeleteAsync();
            return results;
        }

        public async Task<int> AddEventRepoAsync(Event Event)
        {
            _context.Add(Event);
            var results =await _context.SaveChangesAsync();
            return results;
        }

        public async Task<int> UpdateEventRepoAsync(Event Event)
        {
            _context.Events.Update(Event);
            var results = await _context.SaveChangesAsync();
            return results;
        }

        public async Task<List<Event?>> GetEventsByDateTimeRepoAsync(DateTime startdate, DateTime endDate)
        {
            var eventsBydate = await _context.Events.Where(e => e.EventDate>= startdate && e.EventDate <= endDate).ToListAsync();
            return eventsBydate;
        }
        // Den här Operationen under kanske inte behöver implementeras
        public async Task<List<Event?>> GetEventsByCategoriesAndDateRepoAsync(HashSet<string> EventTags, DateTime startdate, DateTime endDate)
        {
            var events = await _context.Events.Include(e => e.Tags).Where(e => e.Tags.Any(e => EventTags.Contains(e.TagName)) && e.EventDate>=startdate && e.EventDate<=endDate).ToListAsync();
            return events;
        }
        public Task<List<Event?>> GetEventsWithDataByDateTimeRepoAsync(DateTime startdate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Event?>> GetEventsByTypeAndDateRepoAsync(EventType EventType, DateTime startdate, DateTime endDate)
        {
            var events = await _context.Events.Where(e => e.Type==EventType && e.EventDate >= startdate && e.EventDate <= endDate).ToListAsync();
            return events;
        }
    }
}

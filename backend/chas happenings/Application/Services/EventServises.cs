using Application.DTOs.EvenDTOs;
using Application.Interfaces.Irepositories;
using Application.Interfaces.IServices;
using static Application.Mappers.DTOMappers.DTOEventMapper;
using static Application.Mappers.DTOMappers.GenericDTOmapper;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class EventServises : IEventServices
    {
        private readonly IEventRepositories _repo;
        public EventServises(IEventRepositories repo)
        {
            _repo = repo;
        }

        public async Task<int> AddEventServicesAsync(CreateEventDTO EventDTO)
        {
            var Event = CreateEventFromDTO(EventDTO);


            var results = await _repo.AddEventRepoAsync(Event);

            if(results > 0)
            {
                return results;
            }

            throw new InvalidOperationException($"Failed to add event to database");
        }

        public async Task<bool> DeleteEventsByIdServicesAsync(int eventId)
        {
            var results = await _repo.DeleteEventsByIdRepoAsync(eventId);

            if(results>0)
            {
                return true;
            }
            return false;

        }

        public async Task<GetEventCalenderDisplayDataDTO> GetEventByIdDisplayDataServicesAsync(int eventId)
        {
            var Event = await _repo.GetEventByIdRepoAsync(eventId);



        }

        public Task<List<Event?>> GetEventsByCategoriesAndDateServicesAsync(HashSet<string> EventTags, DateTime startdate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public Task<List<Event?>> GetEventsByDateTimeServicesAsync(DateTime startdate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public Task<List<Event?>> GetEventsByTypeAndDateServicesAsync(HashSet<string> EventType, DateTime startdate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateEventServicesAsync(UpdateEventDTO eventDto)
        {
            var Event = await _repo.GetEventByIdRepoAsync(eventDto.Id);

            Mapper(Event, eventDto);

            var results = await _repo.UpdateEventRepoAsync(Event);

            if(results>1)
            {
                return true;
            }
            return false;
        }
    }
}

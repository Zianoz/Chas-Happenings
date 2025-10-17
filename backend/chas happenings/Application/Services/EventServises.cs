using Application.DTOs.EvenDTOs;
using Application.Interfaces.Irepositories;
using Application.Interfaces.IServices;
using Application.Mappers.DTOMappers;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Utilitys_Helpers;

namespace Application.Services
{
    internal class EventServises : IEventServices
    {
        private readonly IEventRepositories _repo;
        public EventServises(IEventRepositories repo)
        {
            _repo = repo;
        }

        public async Task<Event> AddEventServicesAsync(CreateEventDTO EventDTO)
        {
            var Event = DTOEventMapper.CreateEventModelFromDTO(EventDTO);

            var EventResponse = await _repo.AddEventRepoAsync(Event);
            var response = DbResponseHandler.DbObjectResponseCheck(EventResponse);

            return response;
        }

        public Task<int> DeleteEventsByIdServicesAsync(int EventId)
        {
            throw new NotImplementedException();
        }

        public Task<Event?> GetEventByIdServicesAsync(int EventId)
        {
            throw new NotImplementedException();
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

        public Task<int> UpdateEventServicesAsync(Event Event)
        {
            throw new NotImplementedException();
        }
    }
}

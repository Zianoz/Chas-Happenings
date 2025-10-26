using Application.DTOs.EvenDTOs;
using Application.Interfaces.Irepositories;
using Application.Interfaces.IServices;
using Application.Mappers.DTOMappers;
using static Application.Mappers.DTOMappers.DTOEventMapper;
using static Application.Mappers.DTOMappers.GenericDTOmapper;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Utilitys_Helpers;
using Domain.Models.ConectionTables;
using Domain.Enums;

namespace Application.Services
{
    public class EventServises : IEventServices
    {
        private readonly IEventRepositories _repo;
        public EventServises(IEventRepositories repo)
        {
            _repo = repo;
        }

        public async Task<bool> AddEventServicesAsync(CreateEventDTO EventDTO, int userId)
        {
            var createdEvent = CreateEventFromDTO(EventDTO);

            createdEvent.Interactions.Add(new UserEvent
            {
                UserId = userId,
                Interaction = Interactions.cretator
            });

            var results = await _repo.AddEventRepoAsync(createdEvent);
            return VerifierUtility.VerifyResponse(results);

        }

        public async Task<bool> DeleteEventsByIdServicesAsync(int eventId)
        {
            var results = await _repo.DeleteEventsByIdRepoAsync(eventId);
            return VerifierUtility.VerifyResponse(results);

        }

        public async Task<GetEventCalenderDisplayDTO> GetEventByIdDisplayDataServicesAsync(int eventId)
        {
            var Event = await _repo.GetEventByIdRepoAsync(eventId);
            var verifiedEvent = VerifierUtility.VerifyObject(Event);
            return DTOEventMapper.MappEventCalenderDisplayData(verifiedEvent);
        }

        public async Task<GetEventWithExtraDataDTO> GetEventByIdWithExtraDataServicesAsync(int eventId)
        {
            var Event = await _repo.GetEventByIdRepoAsync(eventId);
            var verifiedEvent = VerifierUtility.VerifyObject(Event);
            return DTOEventMapper.MappEventWithExtraDataDTO(verifiedEvent);
        }

        public async Task<List<Event?>> GetEventsByCategoriesAndDateServicesAsync(HashSet<string> eventTags, DateTime startdate, DateTime endDate)
        {
            var eventList = await _repo.GetEventsByCategoriesAndDateRepoAsync(eventTags, startdate, endDate);
            foreach(var listedEvent in eventList)
            {
                DTOEventMapper.MappEventCalenderDisplayData(listedEvent);
            }
            return eventList;
        }

        public async Task<List<Event?>> GetEventsByDateTimeServicesAsync(DateTime startdate, DateTime endDate)
        {
            var eventList = await _repo.GetEventsByDateTimeRepoAsync(startdate,endDate);
            foreach(var listedEvent in eventList)
            {
                DTOEventMapper.MappEventCalenderDisplayData(listedEvent);
            }
            return eventList;
        }

        public async Task<List<Event?>> GetEventsByTypeAndDateServicesAsync(HashSet<string> eventTypes, DateTime startdate, DateTime endDate)
        {
            var enumTypes = new HashSet<EventType>();

            foreach (var eventType in eventTypes)
            {
                if(Enum.TryParse<EventType>(eventType, out var enumType))
                {
                    enumTypes.Add(enumType);
                }
            }

            var eventlist = await _repo.GetEventsByTypeAndDateRepoAsync(enumTypes, startdate,endDate);
            
            foreach(var listedEvent in eventlist)
            {
                DTOEventMapper.MappEventCalenderDisplayData(listedEvent);
            }
            return eventlist;
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

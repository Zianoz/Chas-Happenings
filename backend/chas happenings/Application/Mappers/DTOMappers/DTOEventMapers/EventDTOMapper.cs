using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.EvenDTOs;
using Domain.Models;

namespace Application.Mappers.DTOMappers.DTOEventMapers
{
    internal class EventDTOMapper
    {
        public static Event CreateEventFromDTO(CreateEventDTO eventDTO)
        {
            return new Event 
            { 
                
            }
        }
        public static GetEventDataDTO GetEventDTO(Event Event)
        {
            return new GetEventDataDTO
            {

            }
        }
        public static Event UpdateEventFromDTO(UpdateEventDTO eventDTO,Event Event)
        {
            Event.EventTitle = eventDTO.EventTitle;

            return Event;
        }
    }
}

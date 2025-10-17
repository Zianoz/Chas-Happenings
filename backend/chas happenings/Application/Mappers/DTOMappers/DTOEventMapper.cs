using Application.DTOs.EvenDTOs;
using Application.DTOs.TagDTOs;
using Application.DTOs.UserDTOs;
using Application.DTOs.UserEventDTOs;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers.DTOMappers
{
    internal class DTOEventMapper
    {
        public static Event CreateEventModelFromDTO(CreateEventDTO eventDTO)
        {
            return new Event
            {
                Title = eventDTO.Title,
                Description = eventDTO.Description,
                Presentation = eventDTO.Description,
                Text1 = eventDTO.Text1,
                Text2 = eventDTO.Text2,
                EventCreated = eventDTO.EventCreated,
                EventDate = eventDTO.EventDate,
                StartTime = eventDTO.StartTime,
                EndTime = eventDTO.EndTime,
                Location = eventDTO.Location,
                Type = eventDTO.Type,

            };
        }
        public static GetEventWithExtraDataDTO GetEventWithExtraDataDTO(Event Event)
        {
            return new GetEventWithExtraDataDTO
            {
                Id = Event.Id,
                Title = Event.Title,
                Description = Event.Description,
                Presentation = Event.Description,
                Text1 = Event.Text1,
                Text2 = Event.Text2,
                EventCreated = Event.EventCreated,
                EventDate = Event.EventDate,
                StartTime = Event.StartTime,
                EndTime = Event.EndTime,
                Location = Event.Location,
                Type = Event.Type,

                Tags = Event.Tags.Select(t => new GetTagNameDTO
                {
                    TagName = t.TagName

                }).ToList(),

                Comments= Event.Comments.Select(t => t.Id).ToList(),

                Interactions = Event.Interactions.Select(t => new UserEventInteractionDTO
                {
                    Interaction = t.Interaction,
                    User = new GetUserNamePictureDTO
                    {
                        Id = t.User.Id,
                        Username = t.User.Username,
                        ProfilePictureUrl = t.User.ProfilePictureUrl,
                    }
                }).ToList(),

            };
        }
   
    }
}

using Application.DTOs.CommentDTO;
using Application.DTOs.CommentDTOs;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers.DTOMappers
{
    internal class DTOCommentMapper
    {
        public static Comment CreateCommentMapper(CreateCommentDTO commentDTO)
        {
            return new Comment
            {
                AuthorId = commentDTO.UserId,
                EventId = commentDTO.EventId,

                Text = commentDTO.Text,
                ProfilePicture = commentDTO.ProfilePicture,
                CreatedAt = commentDTO.CreatedAt,
            };
        }

        //Iterates over each comment in the collection and maps it to a GetCommentsByEventIdDTO object and returns the collection of mapped DTOs.
        public static IEnumerable<GetCommentsByEventIdDTO> GetCommentsMapper(IEnumerable<Comment> eventComments)
        {
            return eventComments.Select(eventComment => new GetCommentsByEventIdDTO
            {
                Id = eventComment.Id,
                AuthorId = eventComment.AuthorId,
                Username = eventComment.Author.Username,
                ProfilePicture = eventComment.ProfilePicture,
                Text = eventComment.Text,
                EventId = eventComment.EventId,
                CreatedAt = eventComment.CreatedAt
            });
        }

        public static Comment PutCommentMapper(PutCommentDTO dto)
        {
            return new Comment
            {
                Id = dto.Id,
                Text = dto.Text
            };
        }
    }
}
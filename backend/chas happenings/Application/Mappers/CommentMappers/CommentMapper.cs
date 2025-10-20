using Application.DTOs.CommentDTO;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers.CommentMappers
{
    internal class CommentMapper
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
    }
}
using Application.DTOs.CommentDTOs;
using Application.DTOs.UserDTOs;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers.DTOMappers
{
    public class DTOUserMapper
    {
        public static GetUserByIdDTO GetUserByIdMapper(User user)
        {
            return new GetUserByIdDTO
            {
                Id = user.Id,
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Phone = user.Phone,
                Course = user.Course,
                Role = user.Role,
                ProfilePictureUrl = user.ProfilePictureUrl,
                UserDescription = user.UserDescription
            };
        }
    }
}

using Application.DTOs.CommentDTOs;
using Application.DTOs.UserDTOs;
using Domain.Enums;
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

        public static User CreateUserByDTOMapper(CreateUserDTO userDTO)
        {
            return new User
            {
                Username = userDTO.Username,
                PasswordHash = userDTO.Password,
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                Email = userDTO.Email,
                Role = UserRoles.Student
            };
        }

        //?? is a null-coalescing operator it means, If the value on the left is not null, use it. If it is null, use the value on the right instead.
        //So in this context, if the user did send a new field value replace it. Else do not change it.
        public static User UpdateUserByDTOMapper(User user, UpdateUserDTO updateUserDTO)
        {
            user.FirstName = updateUserDTO.FirstName ?? user.FirstName;
            user.LastName = updateUserDTO.LastName ?? user.LastName;
            user.Phone = updateUserDTO.Phone ?? user.Phone;
            user.ProfilePictureUrl = updateUserDTO.ProfilePictureUrl ?? user.ProfilePictureUrl;
            user.UserDescription = updateUserDTO.UserDescription ?? user.UserDescription;
            return user;
        }


    }
}

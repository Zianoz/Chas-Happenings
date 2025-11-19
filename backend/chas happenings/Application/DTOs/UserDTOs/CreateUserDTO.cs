using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.UserDTOs
{
    public class CreateUserDTO
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }

        public string? Phone { get; set; }
        public string? Course { get; set; }
        public UserRoles Role { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public string? UserDescription { get; set; }
    }
}

using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.UserDTOs
{
    public class GetUserNamePictureDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string ProfilePictureUrl { get; set; }

    }
}

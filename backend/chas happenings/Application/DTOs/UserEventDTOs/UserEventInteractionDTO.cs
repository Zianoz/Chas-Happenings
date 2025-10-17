using Application.DTOs.UserDTOs;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.UserEventDTOs
{
    internal class UserEventInteractionDTO
    {
        public GetUserNamePictureDTO User { get; set; }
        public string Interaction { get; set; }
    }
}

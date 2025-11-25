using Application.DTOs.UserDTOs;
using Domain.Enums;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.UserEventDTOs
{
    public class UserEventInteractionDTO
    {
        public GetUserNamePictureDTO User { get; set; }
        public Interactions Interaction { get; set; }
    }
}

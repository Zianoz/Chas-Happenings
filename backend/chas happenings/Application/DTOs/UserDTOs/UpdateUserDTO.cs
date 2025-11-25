using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.UserDTOs
{
    public class UpdateUserDTO : CreateUserDTO
    {
        public int Id { get; set; }
    }
}

using Application.DTOs.UserEventDTOs;
using Domain.Enums;
using Domain.Models;
using Domain.Models.ConectionTables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.EvenDTOs
{
    internal class GetEventCalenderDisplayDataDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public DateTime EventDate { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        [Required]
        public EventType Type { get; set; }
        public ICollection<UserEventInteractionDTO> Interactions { get; set; } = new List<UserEventInteractionDTO>();
    }
}

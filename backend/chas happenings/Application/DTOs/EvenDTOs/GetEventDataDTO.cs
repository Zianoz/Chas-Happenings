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
    internal class GetEventDataDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? Presentation { get; set; }
        public string? Text1 { get; set; }
        public string? Text2 { get; set; }
        public DateTime EventCreated { get; set; } = DateTime.UtcNow;
        [Required]
        public DateTime EventDate { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public TimeSpan? Duration { get; set; }
        public string? Location { get; set; }
        [Required]
        public string EventType { get; set; }
        public ICollection<Tag> Tags { get; set; } = new List<Tag>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<UserEvent> Interactions { get; set; } = new List<UserEvent>();
    }
}

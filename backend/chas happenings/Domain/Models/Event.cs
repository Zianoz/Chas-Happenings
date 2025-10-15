using Domain.Models.ConectionTables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string EventTitle { get; set; }
        public string EventDescription { get; set; }
        public string EventNote { get; set; }
        public string EventNote2 { get; set; }
        //-------------------------------------------------------------------------------------------
        //datetime för  när ett events skappas
        public DateTime EventCreated { get; set; } = DateTime.UtcNow;
        //-------------------------------------------------------------------------------------------
        [Required]
        public DateTime EventDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public TimeSpan Duration { get; set; }
        public string Location { get; set; }
        //-------------------------------------------------------------------------------------------
        // La till en Eventtype jag kommer föreslår att vi gör om EventTyp till en Enum
        public string EventType { get; set; }
        //-------------------------------------------------------------------------------------------
        public ICollection<Tag> Tags { get; set; } = new List<Tag>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<UserEvent> Interactions { get; set; } = new List<UserEvent>();
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.ConectionTables
{
    public class UserEvent
    {
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }


        [ForeignKey("Event")]
        public int EventId { get; set; }
        public Event Event { get; set; }

        public string Interaction { get; set; }
        
        
        // Interaction kan vara flera aker som:    CREATOR, ORGANIZER, LIKED, ATTENDING etcetc
        // baserat på hur man väljer att strukturera interaktion eller roller så kan man använda Enums för att
    }
}

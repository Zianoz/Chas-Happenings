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



        //-------------------------------------------------------------------------------------------
        // INTERACTIONS
        //-------------------------------------------------------------------------------------------
        // Interaction kan vara flera saker som:    CREATOR, ORGANIZER, LIKED, ATTENDING etcetc
        // baserat på hur man väljer att strukturera det kan man använda Enums för att
        // bestäma vilka värden för "interactions" som är tillåtna
        // 
        // Note: Att använda Enums för deta syfte är ganska nytt för mig (max) Så deta kan vara nåt bra att
        //       ta upp tillsamans i gruppen så vi alla kan lära oss samtidigt
    }//-------------------------------------------------------------------------------------------
}

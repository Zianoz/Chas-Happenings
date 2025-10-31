using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string TagName { get; set; }
        [ForeignKey("Events")]
        public int FK_event { get; set; }
        public ICollection<Event> Events { get; set; } = new List<Event>();
    }
}

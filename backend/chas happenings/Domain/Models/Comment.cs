using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public int AuthorId { get; set; }
        public User Author { get; set; }

        public int EventId { get; set; }
        public Event Event { get; set; }

        public string Text { get; set; }
        public string ProfilePicture { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;  
    }
}

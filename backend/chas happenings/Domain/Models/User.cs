using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PasswordHash { get; set; }
        public string Course { get; set; }
        public string Role { get; set; }
        public string ProfilePictureUrl { get; set; }
        public string UserDescription { get; set; }

        public ICollection<Event> CreatedEvents { get; set; } = new List<Event>();
        //public ICollection<UserEventInterested> Interested { get; set; } = new List<UserEventInterested>();
        //public ICollection<UserEventAttending> Attending { get; set; } = new List<UserEventAttending>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}

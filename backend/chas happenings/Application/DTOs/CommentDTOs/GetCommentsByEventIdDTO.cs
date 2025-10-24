using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.CommentDTOs
{
    public class GetCommentsByEventIdDTO
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string Username { get; set; }
        public string ProfilePicture { get; set; }
        public string Text { get; set; }
        public int EventId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

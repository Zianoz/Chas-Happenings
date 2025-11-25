using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.OpenAIDTOs
{
    public class OpenAIResponseDTO
    {
        public string Answer { get; set; }
        public DateTime GeneratedAt { get; set; } = DateTime.UtcNow;
    }
}

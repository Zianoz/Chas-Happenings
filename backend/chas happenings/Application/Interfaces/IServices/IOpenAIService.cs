using Application.DTOs.OpenAIDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IServices
{
    public interface IOpenAIService
    {
        Task<OpenAIResponseDTO> GenerateAnswerAsync(OpenAIRequestDTO request);
    }
}

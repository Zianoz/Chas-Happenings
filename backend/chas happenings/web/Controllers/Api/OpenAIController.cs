using Application.DTOs.OpenAIDTOs;
using Application.Interfaces.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace chas_happenings.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpenAIController : ControllerBase
    {
        private readonly IOpenAIService _openAIService;

        public OpenAIController(IOpenAIService openAIService)
        {
            _openAIService = openAIService;
        }

        [HttpPost("generate")]
        public async Task<ActionResult<OpenAIResponseDTO>> GenerateAnswer([FromBody] OpenAIRequestDTO request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request?.Prompt))
                {
                    return BadRequest(new { message = "Prompt cannot be empty." });
                }

                var response = await _openAIService.GenerateAnswerAsync(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Log the exception (e.g., using ILogger)
                return StatusCode(500, new { message = "An error occurred while generating the answer.", error = ex.Message });
            }
        }

        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok("OpenAI API is running correctly!");
        }
    }
}

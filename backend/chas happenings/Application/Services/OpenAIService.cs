using Application.DTOs.OpenAIDTOs;
using Application.Interfaces.IServices;
using Microsoft.Extensions.Configuration;
using Azure;
using Azure.AI.OpenAI;
using OpenAI.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class OpenAIService : IOpenAIService
    {
        private readonly AzureOpenAIClient _client;
        private readonly string _deployment;

        public OpenAIService(IConfiguration config)
        {
            var endpoint = config["AzureOpenAI:Endpoint"];
            var apiKey = config["AzureOpenAI:ApiKey"];
            _deployment = config["AzureOpenAI:Deployment"];

            _client = new AzureOpenAIClient(
                new Uri(endpoint),
                new AzureKeyCredential(apiKey)
            );
        }

        public async Task<OpenAIResponseDTO> GenerateAnswerAsync(OpenAIRequestDTO request)
        {
            var chatClient = _client.GetChatClient(_deployment);
            
            var response = await chatClient.CompleteChatAsync(
                new ChatMessage[]
                {
                    new UserChatMessage(request.Prompt)
                }
            );

            return new OpenAIResponseDTO
            {
                Answer = response.Value.Content[0].Text,
                GeneratedAt = DateTime.UtcNow
            };
        }
    }
}

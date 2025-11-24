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
        private readonly IEventServices _eventServices;

        public OpenAIService(IConfiguration config, IEventServices eventServices)
        {
            var endpoint = config["AzureOpenAI:Endpoint"];
            var apiKey = config["AzureOpenAI:ApiKey"];
            _deployment = config["AzureOpenAI:Deployment"];

            _client = new AzureOpenAIClient(
                new Uri(endpoint),
                new AzureKeyCredential(apiKey)
            );
            
            _eventServices = eventServices;
        }

        public async Task<OpenAIResponseDTO> GenerateAnswerAsync(OpenAIRequestDTO request)
        {
            var chatClient = _client.GetChatClient(_deployment);

            var response = await chatClient.CompleteChatAsync(
                new ChatMessage[]
                {
                    new SystemChatMessage("You are a friendly, concise chatbot who explains and summarizes stuff to university students."), //System prompt
                    new UserChatMessage(request.Prompt) //User prompt
                }
            );

            return new OpenAIResponseDTO
            {
                Answer = response.Value.Content[0].Text,
                GeneratedAt = DateTime.UtcNow
            };
        }

        private string BuildEventContext(dynamic upcomingThisWeek, dynamic pastWeek, dynamic allUpcoming)
        {
            var context = new StringBuilder();
            
            context.AppendLine("\n=== UPCOMING EVENTS THIS WEEK ===");
            if (upcomingThisWeek != null && upcomingThisWeek.Count > 0)
            {
                foreach (var evt in upcomingThisWeek)
                {
                    var timeInfo = evt.StartTime != null 
                        ? $" at {evt.StartTime}" 
                        : "";
                    context.AppendLine($"• {evt.Title} - {evt.EventDate:MMM dd, yyyy}{timeInfo} ({evt.Type})");
                }
            }
            else
            {
                context.AppendLine("No events scheduled for this week.");
            }

            context.AppendLine("\n=== PAST EVENTS (LAST WEEK) ===");
            if (pastWeek != null && pastWeek.Count > 0)
            {
                foreach (var evt in pastWeek)
                {
                    var timeInfo = evt.StartTime != null 
                        ? $" at {evt.StartTime}" 
                        : "";
                    context.AppendLine($"• {evt.Title} - {evt.EventDate:MMM dd, yyyy}{timeInfo} ({evt.Type})");
                }
            }
            else
            {
                context.AppendLine("No events in the past week.");
            }

            context.AppendLine("\n=== ALL UPCOMING EVENTS (NEXT 30 DAYS) ===");
            if (allUpcoming != null && allUpcoming.Count > 0)
            {
                foreach (var evt in allUpcoming)
                {
                    var timeInfo = evt.StartTime != null 
                        ? $" at {evt.StartTime}" 
                        : "";
                    context.AppendLine($"• {evt.Title} - {evt.EventDate:MMM dd, yyyy}{timeInfo} ({evt.Type})");
                }
            }
            else
            {
                context.AppendLine("No upcoming events in the next 30 days.");
            }

            context.AppendLine($"\nToday's date: {DateTime.UtcNow:MMM dd, yyyy}");

            return context.ToString();
        }
    }
}

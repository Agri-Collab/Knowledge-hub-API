using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using api.Models;
using api.Repositories;
using Microsoft.Extensions.Configuration;

namespace api.Services
{
    public class ChatService : IChatService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly IChatRepository _chatRepository;

        public ChatService(IConfiguration configuration, IChatRepository chatRepository)
        {
            _apiKey = configuration["OpenAI:ApiKey"];
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", _apiKey);

            _chatRepository = chatRepository;
        }

        public async Task<string> SendMessageAsync(string userId, string userMessage)
        {
            await _chatRepository.AddMessageAsync(new ChatMessage
            {
                UserId = userId,
                Sender = "user",
                Message = userMessage
            });

            var requestBody = new
            {
                model = "gpt-3.5-turbo",
                messages = new[]
                {
                    new { role = "user", content = userMessage }
                }
            };

            var content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("https://api.openai.com/v1/chat/completions", content);
            var responseContent = await response.Content.ReadAsStringAsync();

            using var doc = JsonDocument.Parse(responseContent);
            var botMessageContent = doc.RootElement
                .GetProperty("choices")[0]
                .GetProperty("message")
                .GetProperty("content")
                .GetString() ?? "No response from GPT";

            await _chatRepository.AddMessageAsync(new ChatMessage
            {
                UserId = userId,
                Sender = "bot",
                Message = botMessageContent
            });

            return botMessageContent;
        }

        public async Task<string> SendMessageAsync(int sessionId, string userMessage)
        {
            string userId = $"session-{sessionId}";
            return await SendMessageAsync(userId, userMessage);
        }
    }
}

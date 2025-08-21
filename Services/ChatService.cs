using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using api.Services;

public class ChatService : IChatService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;

    public ChatService(IConfiguration configuration)
    {
        _apiKey = configuration["OpenAI:ApiKey"];
        _httpClient = new HttpClient();
        _httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", _apiKey);
    }

    public async Task<string> SendMessageAsync(string userMessage)
    {
        Console.WriteLine($"[ChatService] Sending message to OpenAI: {userMessage}");

        var requestBody = new
        {
            model = "gpt-3.5-turbo",
            messages = new[]
            {
                new { role = "user", content = userMessage }
            }
        };

        var content = new StringContent(
            JsonSerializer.Serialize(requestBody),
            Encoding.UTF8,
            "application/json"
        );

        try
        {
            var response = await _httpClient.PostAsync(
                "https://api.openai.com/v1/chat/completions",
                content
            );

            Console.WriteLine($"[ChatService] Response status code: {response.StatusCode}");

            var responseContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"[ChatService] Response content: {responseContent}");

            if (!response.IsSuccessStatusCode)
            {
                return $"Error: {response.StatusCode} - {responseContent}";
            }

            using var doc = JsonDocument.Parse(responseContent);
            var message = doc.RootElement
                .GetProperty("choices")[0]
                .GetProperty("message")
                .GetProperty("content")
                .GetString();

            return message ?? "No response from GPT";
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"[ChatService] HTTP error: {ex.Message}");
            return $"HTTP error: {ex.Message}";
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ChatService] Unexpected error: {ex.Message}");
            return $"Unexpected error: {ex.Message}";
        }
    }

    public async Task<string> SendMessageAsync(int sessionId, string userMessage)
    {
        // Optional: implement session-based chat history
        return await SendMessageAsync(userMessage);
    }
}

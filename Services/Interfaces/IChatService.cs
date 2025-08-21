namespace api.Services
{
    public interface IChatService
    {
        Task<string> SendMessageAsync(string userMessage);
        Task<string> SendMessageAsync(int sessionId, string userMessage);
    }
}

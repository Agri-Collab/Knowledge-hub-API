using System.Threading.Tasks;

namespace api.Services
{
    public interface IChatService
    {

        Task<string> SendMessageAsync(string userId, string userMessage);

        Task<string> SendMessageAsync(int sessionId, string userMessage);
    }
}

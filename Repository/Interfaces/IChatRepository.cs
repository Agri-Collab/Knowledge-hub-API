using api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.Repositories
{
    public interface IChatRepository
    {
        Task AddMessageAsync(ChatMessage message);
        Task<List<ChatMessage>> GetMessagesByUserAsync(string userId);
        Task<List<ChatMessage>> GetAllMessagesAsync();
    }
}

using api.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.Services.Interfaces
{
    public interface IPrivateChatService
    {
        Task<PrivateChatDto> GetOrCreateChatAsync(int user1Id, int user2Id);
        Task<IEnumerable<PrivateChatDto>> GetChatsForUserAsync(int userId);
        Task<PrivateChatDto> GetChatByIdAsync(int chatId);
    }
}

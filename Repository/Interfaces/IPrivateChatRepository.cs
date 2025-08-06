using api.Models;

public interface IPrivateChatRepository
{
    Task<PrivateChat> GetOrCreateChatAsync(int user1Id, int user2Id);
    Task<IEnumerable<PrivateChat>> GetChatsForUserAsync(int userId);
    Task<PrivateChat> GetChatByIdAsync(int chatId);
}

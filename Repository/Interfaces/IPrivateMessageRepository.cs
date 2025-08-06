using api.Models;

public interface IPrivateMessageRepository
{
    Task SendMessageAsync(PrivateMessage message);
    Task<IEnumerable<PrivateMessage>> GetMessagesForChatAsync(int chatId);
}

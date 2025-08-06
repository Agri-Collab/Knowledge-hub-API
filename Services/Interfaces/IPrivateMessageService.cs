using api.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.Services.Interfaces
{
    public interface IPrivateMessageService
    {
        Task<PrivateMessageDto> SendMessageAsync(int senderId, int chatId, string content);
        Task<IEnumerable<PrivateMessageDto>> GetMessagesForChatAsync(int chatId);
    }
}

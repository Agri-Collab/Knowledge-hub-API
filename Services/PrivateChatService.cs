using api.Dtos;
using api.Models;
using api.Repository.Interfaces;
using api.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Services
{
    public class PrivateChatService : IPrivateChatService
    {
        private readonly IPrivateChatRepository _chatRepository;

        public PrivateChatService(IPrivateChatRepository chatRepository)
        {
            _chatRepository = chatRepository;
        }

        public async Task<PrivateChatDto> GetOrCreateChatAsync(int user1Id, int user2Id)
        {
            var chat = await _chatRepository.GetOrCreateChatAsync(user1Id, user2Id);
            return MapToDto(chat);
        }

        public async Task<IEnumerable<PrivateChatDto>> GetChatsForUserAsync(int userId)
        {
            var chats = await _chatRepository.GetChatsForUserAsync(userId);
            return chats.Select(MapToDto);
        }

        public async Task<PrivateChatDto> GetChatByIdAsync(int chatId)
        {
            var chat = await _chatRepository.GetChatByIdAsync(chatId);
            return MapToDto(chat);
        }

        private PrivateChatDto MapToDto(PrivateChat chat)
        {
            return new PrivateChatDto
            {
                Id = chat.Id,
                User1Id = chat.User1Id,
                User2Id = chat.User2Id,
                User1Name = chat.User1?.UserName,
                User2Name = chat.User2?.UserName,
                CreatedAt = chat.CreatedAt
            };
        }
    }
}

using api.Dto;
using api.Models;
using api.Repository.Interfaces;
using api.Services.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.Services
{
    public class PrivateMessageService : IPrivateMessageService
    {
        private readonly IPrivateMessageRepository _messageRepository;
        private readonly IMapper _mapper;

        public PrivateMessageService(IPrivateMessageRepository messageRepository, IMapper mapper)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
        }

        public async Task<PrivateMessageDto> SendMessageAsync(int senderId, int chatId, string content)
        {
            var message = new PrivateMessage
            {
                SenderId = senderId,
                ChatId = chatId,
                Content = content,
                SentAt = DateTime.UtcNow,
                IsRead = false
            };

            await _messageRepository.SendMessageAsync(message);
            return _mapper.Map<PrivateMessageDto>(message);
        }

        public async Task<IEnumerable<PrivateMessageDto>> GetMessagesForChatAsync(int chatId)
        {
            var messages = await _messageRepository.GetMessagesForChatAsync(chatId);
            return _mapper.Map<IEnumerable<PrivateMessageDto>>(messages);
        }
    }
}

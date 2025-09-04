using api.DTOs;
using api.Repositories;
using api.Models;
using api.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly IChatService _chatService;
        private readonly IChatRepository _chatRepository;

        public ChatController(IChatService chatService, IChatRepository chatRepository)
        {
            _chatService = chatService;
            _chatRepository = chatRepository;
        }

        [HttpPost("send")]
        public async Task<IActionResult> Send([FromBody] ChatRequestDto dto)
        {
            if (dto == null || string.IsNullOrWhiteSpace(dto.UserId) || string.IsNullOrWhiteSpace(dto.Message))
                return BadRequest("UserId and Message are required.");

            var botResponse = await _chatService.SendMessageAsync(dto.UserId, dto.Message);

            return Ok(new ChatResponseDto
            {
                Sender = "bot",
                Message = botResponse,
                Timestamp = DateTime.UtcNow,
                UserId = dto.UserId
            });
        }

        [HttpGet("history/{userId}")]
        public async Task<IActionResult> History(string userId)
        {
            var messages = await _chatRepository.GetMessagesByUserAsync(userId);

            var history = messages.Select(m => new ChatResponseDto
            {
                Sender = m.Sender,
                Message = m.Message,
                Timestamp = m.Timestamp,
                UserId = m.UserId
            }).ToList();

            return Ok(history);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllHistory()
        {
            var messages = await _chatRepository.GetAllMessagesAsync();

            var history = messages.Select(m => new ChatResponseDto
            {
                Sender = m.Sender,
                Message = m.Message,
                Timestamp = m.Timestamp,
                UserId = m.UserId
            }).ToList();

            return Ok(history);
        }
    }
}

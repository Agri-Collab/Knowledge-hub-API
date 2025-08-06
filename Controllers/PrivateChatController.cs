using api.Dtos;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class PrivateChatController : ControllerBase
    {
        private readonly IPrivateChatService _chatService;

        public PrivateChatController(IPrivateChatService chatService)
        {
            _chatService = chatService;
        }

        [HttpGet("user")]
        public async Task<ActionResult<IEnumerable<PrivateChatDto>>> GetChatsForUser()
        {
            var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userIdClaim))
                return Unauthorized("User ID claim missing in token.");

            if (!int.TryParse(userIdClaim, out var userId))
                return BadRequest("Invalid user ID claim.");

            var chats = await _chatService.GetChatsForUserAsync(userId);
            return Ok(chats);
        }

        [HttpGet("{chatId}")]
        public async Task<ActionResult<PrivateChatDto>> GetChatById(int chatId)
        {
            var chat = await _chatService.GetChatByIdAsync(chatId);
            if (chat == null)
                return NotFound();

            return Ok(chat);
        }

        [HttpPost("start/{otherUserId}")]
        public async Task<ActionResult<PrivateChatDto>> StartOrGetChat(int otherUserId)
        {
            var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userIdClaim))
                return Unauthorized("User ID claim missing in token.");

            if (!int.TryParse(userIdClaim, out var currentUserId))
                return BadRequest("Invalid user ID claim.");

            if (currentUserId == otherUserId)
                return BadRequest("Cannot start a chat with yourself.");

            var chat = await _chatService.GetOrCreateChatAsync(currentUserId, otherUserId);
            return Ok(chat);
        }
    }
}

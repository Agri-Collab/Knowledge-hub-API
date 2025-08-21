using Microsoft.AspNetCore.Mvc;
using api.Dtos;
using api.Services;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly IChatService _chatService;

        public ChatController(IChatService chatService)
        {
            _chatService = chatService;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendMessage([FromBody] ChatRequestDto request)
        {
            if (string.IsNullOrWhiteSpace(request.Message))
                return BadRequest("Message cannot be empty.");

            try
            {
                var response = await _chatService.SendMessageAsync(request.Message);
                return Ok(new { Response = response });
            }
            catch (HttpRequestException ex)
            {
                // Handles network errors or API errors other than 429
                return StatusCode(500, new { Error = ex.Message });
            }
        }
    }
}

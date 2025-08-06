using Microsoft.AspNetCore.Mvc;
using api.Services.Interfaces;
using api.Dto;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrivateMessageController : ControllerBase
    {
        private readonly IPrivateMessageService _privateMessageService;

        public PrivateMessageController(IPrivateMessageService privateMessageService)
        {
            _privateMessageService = privateMessageService;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendMessage([FromBody] PrivateMessageForCreateDto dto)
        {
            if (dto == null || string.IsNullOrWhiteSpace(dto.Content))
                return BadRequest("Invalid message content.");

            var message = await _privateMessageService.SendMessageAsync(dto.SenderId, dto.ChatId, dto.Content);
            return Ok(message);
        }
    }

}

using System.Collections.Generic;

namespace api.DTOs
{
    public class ChatHistoryDto
    {
        public string UserId { get; set; } = string.Empty;
        public List<ChatResponseDto> Messages { get; set; } = new List<ChatResponseDto>();
    }
}

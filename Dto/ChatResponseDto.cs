namespace api.DTOs
{
    public class ChatResponseDto
    {
        public string Sender { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }
        public string UserId { get; set; } 
    }
}

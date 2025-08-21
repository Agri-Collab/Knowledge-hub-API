namespace api.Models
{
    public class ChatMessage
    {
        public int Id { get; set; }
        public string Sender { get; set; } // "user" or "bot"
        public string Message { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}
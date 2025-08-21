namespace api.Models
{
    public class ChatSession
    {
        public int Id { get; set; }
        public string SessionName { get; set; }
        public List<ChatMessage> Messages { get; set; } = new();
    }
}
namespace api.Dto
{
    public class PrivateMessageForCreateDto
    {
        public int SenderId { get; set; }
        public int ChatId { get; set; }
        public string Content { get; set; } = string.Empty;
    }
}

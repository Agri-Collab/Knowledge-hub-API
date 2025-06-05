namespace api.Dto
{
    public class CommentForUpdateDto
    {
        public string Body { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}

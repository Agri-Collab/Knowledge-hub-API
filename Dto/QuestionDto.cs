namespace api.Dto
{
    public class QuestionDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Body { get; set; } = null!;
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int VoteCount { get; set; }
    }
}
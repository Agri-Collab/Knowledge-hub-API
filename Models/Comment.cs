
namespace api.Models
{
    public class Comment
    {
        public int Id { get; set; }
        //public string Body { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public int UserId { get; set; }
        public User User { get; set; }

        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}

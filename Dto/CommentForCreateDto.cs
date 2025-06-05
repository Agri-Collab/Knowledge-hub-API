using System.ComponentModel.DataAnnotations;

namespace api.Dto
{
    public class CommentForCreateDto
    {
        [Required(ErrorMessage = "Comment can not be empty")]
        public string Content { get; set; }
        public int UserId { get; set; }
        public int QuestionId { get; set; }
    }
}
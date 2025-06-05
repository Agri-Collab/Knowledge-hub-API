using System.ComponentModel.DataAnnotations;

namespace api.Dto
{
    public class QuestionForCreateDto
    {
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; } = null!;
        
        [Required(ErrorMessage = "Body is required")]
        public string Body { get; set; } = null!;
        public int UserId { get; set; }
    }
}
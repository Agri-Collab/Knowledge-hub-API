using System.ComponentModel.DataAnnotations;

namespace api.Dto
{
    public class ArticleForCreateDto
    {
        [Required]
        [MaxLength(250)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public int UserId { get; set; }
    }

}

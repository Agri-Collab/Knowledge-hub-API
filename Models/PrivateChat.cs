using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class PrivateChat
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int User1Id { get; set; }

        [Required]
        public int User2Id { get; set; }

        [ForeignKey(nameof(User1Id))]
        public User User1 { get; set; }

        [ForeignKey(nameof(User2Id))]
        public User User2 { get; set; }

        public ICollection<PrivateMessage> Messages { get; set; } = new List<PrivateMessage>();

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class PrivateMessage
    {
        public int Id { get; set; }
        public int ChatId { get; set; }
        public PrivateChat Chat { get; set; }
        public int SenderId { get; set; }
        public User Sender { get; set; }
        public string Content { get; set; }
        public DateTime SentAt { get; set; } = DateTime.UtcNow;
        public bool IsRead { get; set; } = false;
    }

}

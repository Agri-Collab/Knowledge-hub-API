using Microsoft.AspNetCore.Identity;
namespace api.Models
{
    public class User : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ContactNo { get; set; }
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<Article> Articles { get; set; } = new List<Article>();
         public ICollection<PrivateChat> PrivateChatsAsUser1 { get; set; } = new List<PrivateChat>();
        public ICollection<PrivateChat> PrivateChatsAsUser2 { get; set; } = new List<PrivateChat>();
        public ICollection<PrivateMessage> SentMessages { get; set; } = new List<PrivateMessage>();

    }
}
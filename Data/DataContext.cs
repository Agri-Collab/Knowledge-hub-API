using api.Configuration;
using api.Configurations;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class DataContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new QuestionConfiguration());
            modelBuilder.ApplyConfiguration(new ArticleConfiguration());
            modelBuilder.ApplyConfiguration(new PrivateChatConfiguration());
            modelBuilder.ApplyConfiguration(new PrivateMessageConfiguration());

            modelBuilder.Entity<AdvertisementRequest>()
                .HasOne(a => a.User)
                .WithMany(u => u.AdvertisementRequests)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<PrivateChat> PrivateChats { get; set; }
        public DbSet<PrivateMessage> PrivateMessages { get; set; }
        public DbSet<ChatMessage> ChatMessages { get; set; }
        public DbSet<ChatSession> ChatSessions { get; set; }
        public DbSet<AdvertisementRequest> AdvertisementRequests { get; set; }
    }
}

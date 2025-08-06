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
        }


        public DbSet<Question> Questions { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<PrivateChat> PrivateChats { get; set; }
        public DbSet<PrivateMessage> PrivateMessages { get; set; }
        
    }
}

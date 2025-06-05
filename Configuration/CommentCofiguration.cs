// In api.Configuration.CommentConfiguration.cs
using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Configuration
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            // Configure table name if needed
            builder.ToTable("Comments");

            // Configure primary key (if not by convention)
            builder.HasKey(c => c.Id);

            // Configure properties
            builder.Property(c => c.Content)
                .IsRequired()
                .HasMaxLength(1000); // example max length

            builder.Property(c => c.CreatedAt)
                .HasDefaultValueSql("now()"); // PostgreSQL current timestamp

            // Configure relationship with User
            builder.HasOne(c => c.User)
                .WithMany(u => u.Comments) // assuming User has ICollection<Comment> Comments
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict); // or Cascade, depending on your needs

            // Optionally seed some comments data
            builder.HasData(
                new Comment
                {
                    Id = 1,
                    Content = "This is a seeded comment.",
                    CreatedAt = System.DateTime.UtcNow,
                    UserId = 1,
                    QuestionId = 1
                },
                new Comment
                {
                    Id = 2,
                    Content = "Another comment by test user.",
                    CreatedAt = System.DateTime.UtcNow,
                    UserId = 2,
                    QuestionId = 1
                }
            );
        }
    }
}

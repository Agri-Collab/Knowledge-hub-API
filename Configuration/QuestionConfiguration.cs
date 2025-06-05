using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace api.Configuration
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasKey(q => q.Id);

            builder.Property(q => q.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(q => q.Body)
                .IsRequired();

            builder.Property(q => q.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'");

            builder.Property(q => q.VoteCount)
                .HasDefaultValue(0);

            builder.HasOne(q => q.User)
                   .WithMany()
                   .HasForeignKey(q => q.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasData
            (
                new Question
                {
                    Id = 1,
                    Title = "How do I configure Entity Framework Core migrations?",
                    Body = "I'm trying to add and apply migrations in my ASP.NET Core project, but I'm running into errors. What is the correct sequence of commands?",
                    UserId = 1,
                    CreatedAt = new DateTime(2025, 1, 10, 14, 30, 0, DateTimeKind.Utc),
                    UpdatedAt = null,
                    VoteCount = 5
                },
                new Question
                {
                    Id = 2,
                    Title = "What's the difference between AddDbContext and AddDbContextPool?",
                    Body = "I see both AddDbContext and AddDbContextPool in the docs. When should I use one over the other in ASP.NET Core?",
                    UserId = 2,
                    CreatedAt = new DateTime(2025, 2, 5, 9, 0, 0, DateTimeKind.Utc),
                    UpdatedAt = null,
                    VoteCount = 3
                }
            );
        }
    }
}

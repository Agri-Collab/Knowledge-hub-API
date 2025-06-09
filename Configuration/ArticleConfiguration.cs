using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using api.Models;

namespace api.Configurations
{
    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.ToTable("Articles");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Title)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(a => a.Content)
                .IsRequired();

            builder.Property(a => a.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.HasOne(a => a.User)
                .WithMany(u => u.Articles)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.HasData(
                new Article
                {
                    Id = 1,
                    Title = "Getting Started with ASP.NET Core",
                    Content = "This article explains how to set up a basic ASP.NET Core project...",
                    CreatedAt = new DateTime(2024, 01, 01, 12, 0, 0, DateTimeKind.Utc),
                    UserId = 1
                },
                new Article
                {
                    Id = 2,
                    Title = "Entity Framework Core Relationships",
                    Content = "Learn how to define and manage relationships using EF Core...",
                    CreatedAt = new DateTime(2024, 01, 02, 12, 0, 0, DateTimeKind.Utc),
                    UserId = 1
                }
            );

        }
    }
}

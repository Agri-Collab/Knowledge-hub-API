using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Configurations
{
    public class PrivateMessageConfiguration : IEntityTypeConfiguration<PrivateMessage>
    {
        public void Configure(EntityTypeBuilder<PrivateMessage> builder)
        {
            builder.HasKey(pm => pm.Id);

            builder
                .HasOne(pm => pm.Chat)
                .WithMany(pc => pc.Messages)
                .HasForeignKey(pm => pm.ChatId);

            builder
                .HasOne(pm => pm.Sender)
                .WithMany(u => u.SentMessages)
                .HasForeignKey(pm => pm.SenderId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

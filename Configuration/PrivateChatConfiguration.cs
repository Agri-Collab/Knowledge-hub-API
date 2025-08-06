using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Configurations
{
    public class PrivateChatConfiguration : IEntityTypeConfiguration<PrivateChat>
    {
        public void Configure(EntityTypeBuilder<PrivateChat> builder)
        {
            builder.HasKey(pc => pc.Id);

            builder
                .HasOne(pc => pc.User1)
                .WithMany(u => u.PrivateChatsAsUser1)
                .HasForeignKey(pc => pc.User1Id)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(pc => pc.User2)
                .WithMany(u => u.PrivateChatsAsUser2)
                .HasForeignKey(pc => pc.User2Id)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

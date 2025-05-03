using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData
            (
                new User
                {
                    Id = 1,
                    Name = "Nduvho",
                    Surname = "Maguwada",
                    ContactNo = 0646974038,
                    //CreatedAt = DateTime.Now,
                },
                new User
                {
                    Id = 2,
                    Name = "Themba",
                    Surname = "Cele",
                    ContactNo = 0728898987,
                    //CreatedAt = DateTime.Now,
                }
            );
        }
    }
}

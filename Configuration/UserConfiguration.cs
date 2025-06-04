// In api.Configuration.UserConfiguration.cs
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
                    UserName = "admin@example.com",
                    NormalizedUserName = "ADMIN@EXAMPLE.COM",
                    Email = "admin@example.com",
                    NormalizedEmail = "ADMIN@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAIAAYagAAAAEHqv6PdMX+oZQXdq8J6GnVUx6edV+XXjMMn37jLmMaX4EgI7opxS667OMwonfQxMOg==",
                    SecurityStamp = "a1b2c3d4-e5f6-7890-1234-567890abcdef",
                    Name = "Admin",
                    Surname = "User",
                    ContactNo = "1234567890",
                    ConcurrencyStamp = "44c96145-97a1-4a7b-83c0-54aa555c3b68"

                },
                new User
                {
                    Id = 2,
                    UserName = "testuser@example.com",
                    NormalizedUserName = "TESTUSER@EXAMPLE.COM",
                    Email = "testuser@example.com",
                    NormalizedEmail = "TESTUSER@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAIAAYagAAAAEDLQ4y9K6Z3CGg8bivta7fyW1NNiOa5eTKGfsQSZkva8fmxqxLGzL2t6xxCEL2Yw3Q==",
                    SecurityStamp = "f1e2d3c4-b5a6-9876-5432-10fedcba9876",
                    Name = "Test",
                    Surname = "Users",
                    ContactNo = "987654210",
                    ConcurrencyStamp = "72e12b07-bdf6-460e-a777-32b228f89c22"
                }
            );
        }
    }
}
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
                    ContactNo = 948998437,
                    Email = "nduvho@gmail.com",
                   
                   
                },
                new User
                {
                    Id = 2,
                    Name = "Lesley",
                    Surname = "Maf",
                    ContactNo = 89876076,
                    Email = "lesley@gmai.com",

                }
            );
        }
    }
}

using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class RepositoryContext : DbContext
{
        public RepositoryContext(DbContextOptions options)
        : base(options)
        {
        }
        public DbSet<User>? Users { get; set; }
}
}
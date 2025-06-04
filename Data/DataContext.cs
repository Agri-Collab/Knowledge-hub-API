using api.Configuration;
using api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore; // Make sure this is present
using Microsoft.AspNetCore.Identity; // Make sure this is present for IdentityRole<int>

namespace api.Data
{
    // Change this line:
    // public class DataContext : IdentityDbContext<User, IdentityRole, int>
    // To this:
    public class DataContext : IdentityDbContext<User, IdentityRole<int>, int> // <-- Use IdentityRole<int>
    {
        public DataContext(DbContextOptions<DataContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Always call base for IdentityDbContext

            modelBuilder.ApplyConfiguration(new UserConfiguration());

            // You might need to remove/adjust UserConfiguration if it conflicts with Identity's built-in User table mapping.
            // If UserConfiguration maps to a table named 'Users' for User, it will conflict with Identity's 'AspNetUsers'.
            // Consider if you still need it or if it needs to map to a different table.
            // For now, let's assume it's okay or you'll address migration conflicts later.
        }

        // Remove this if your UserConfiguration was for a separate 'Users' table; IdentityDbContext provides it.
        // public DbSet<User> Users { get; set; }

        public DbSet<Product> Products { get; set;}
    }
}
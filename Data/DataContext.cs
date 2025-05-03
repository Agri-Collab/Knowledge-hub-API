using api.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace api.Data
{
    public class DataContext : DbContext 
    {
        public DataContext(DbContextOptions<DataContext> options)
        : base(options)
        { 

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            //modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set;}

    }


}
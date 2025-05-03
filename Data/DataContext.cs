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
        public DbSet<User> Users { get; set; }

    }
}
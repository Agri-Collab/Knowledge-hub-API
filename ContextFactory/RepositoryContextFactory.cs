using api.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ContextFactory
{
    public class RepositoryContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
        {
            public RepositoryContext CreateDbContext(string[] args)
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
                var builder = new DbContextOptionsBuilder<RepositoryContext>()
                    .UseSqlServer(configuration.GetConnectionString("sqlConnection"),
                    b => b.MigrationsAssembly("Users"))
                    .UseSqlServer(configuration.GetConnectionString("Server=localhost;Port=5432;Database=AgriConnect;Username=nduvhomaguwada;Password=@Nduvho2001"
));
                return new RepositoryContext(builder.Options);
            }
        }
}
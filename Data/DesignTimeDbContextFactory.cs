using api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DataContext>
{
    public DataContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
        optionsBuilder.UseSqlServer("Server=localhost;Port=5432;Database=AgriConnect;Username=nduvhomaguwada;Password=@Nduvho2001");

        return new DataContext(optionsBuilder.Options);
    }
}

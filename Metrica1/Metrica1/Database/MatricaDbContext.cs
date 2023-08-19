using Microsoft.EntityFrameworkCore;
using Metrica1.Database.Models;

namespace Pustok.Database;

public class MatricaDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = "Server=localhost;Port=5432;Database=Metrica;User Id=postgres;Password=postgresql;";

        optionsBuilder.UseNpgsql(connectionString);

        base.OnConfiguring(optionsBuilder);
    }

    public DbSet<Product> Products { get; set; }
  
}

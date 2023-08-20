using Metrica1.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Metrica.Database;

public class MatricaDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=MetricaEmployee1;User Id=postgres;Password=postgresql;");

        base.OnConfiguring(optionsBuilder);
    }

    public DbSet<Employee> Employees { get; set; }

    public DbSet<Agency> Agencies { get; set; }

}

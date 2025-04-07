namespace TravelAgency.model.repository;

using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Package> Packages { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<BoughtPackage> BoughtPackages { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite("Data Source=travel_agency.db");
    }
}

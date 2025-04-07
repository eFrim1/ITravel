namespace TravelAgency.model.repository;

public class PackageRepository : GenericRepository<Package>
{
    public PackageRepository(AppDbContext context) : base(context) { context.Database.EnsureCreated(); }
}

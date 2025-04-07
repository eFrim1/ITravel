namespace TravelAgency.model.repository;

public class BoughtPackageRepository : GenericRepository<BoughtPackage>
{
    public BoughtPackageRepository(AppDbContext context) : base(context) {context.Database.EnsureCreated(); }
}

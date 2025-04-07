namespace TravelAgency.model.repository;

public class ClientRepository : GenericRepository<Client>
{
    public ClientRepository(AppDbContext context) : base(context) {context.Database.EnsureCreated(); }
}

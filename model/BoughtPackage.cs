namespace TravelAgency.model;

public class BoughtPackage
{
    public BoughtPackage() {}

    public BoughtPackage(int id, int packageId, int clientId, DateTime boughtDate, DateTime departure, DateTime arrival)
    {
        Id = id;
        PackageId = packageId;
        ClientId = clientId;
        BoughtDate = boughtDate;
        Departure = departure;
        Arrival = arrival;
    }
    
    public BoughtPackage(int packageId, int clientId, DateTime boughtDate, DateTime departure, DateTime arrival)
    {
        PackageId = packageId;
        ClientId = clientId;
        BoughtDate = boughtDate;
        Departure = departure;
        Arrival = arrival;
    }

    public int Id { get; set; }
    public int PackageId { get; set; }
    public int ClientId { get; set; }
    public DateTime BoughtDate { get; set; }
    public DateTime Departure { get; set; }
    public DateTime Arrival { get; set; }

    public Package? Package { get; set; }  // Navigation Property
    public Client? Client { get; set; }    // Navigation Property
}

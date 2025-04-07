namespace TravelAgency.model;

public class Package
{
    public Package() {}
    public Package(int id, string destination, int period, decimal price, string? image1, string? image2, string? image3)
    {
        Id = id;
        Destination = destination;
        Period = period;
        Price = price;
        Image1 = image1;
        Image2 = image2;
        Image3 = image3;
    }
    public Package(string destination, int period, decimal price, string? image1, string? image2, string? image3)
    {
        Destination = destination;
        Period = period;
        Price = price;
        Image1 = image1;
        Image2 = image2;
        Image3 = image3;
    }
    public int Id { get; set; }
    public string Destination { get; set; }
    public int Period { get; set; }
    public decimal Price { get; set; }
    public string? Image1 { get; set; }
    public string? Image2 { get; set; }
    public string? Image3 { get; set; }
}

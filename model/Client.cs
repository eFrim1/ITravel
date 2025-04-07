namespace TravelAgency.model;

public class Client
{
    public Client() { }
    public Client(int id, string name, string email, string phone)
    {
        Id = id;
        Name = name;
        Email = email;
        Phone = phone;
    }
    public Client(string name, string email, string phone)
    {
        Name = name;
        Email = email;
        Phone = phone;
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
}
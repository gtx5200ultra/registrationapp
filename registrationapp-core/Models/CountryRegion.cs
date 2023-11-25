namespace registrationapp_core.Models;

public class CountryRegion
{
    public int Id { get; set; }

    public string Name { get; set; }


    public int CountryId { get; set; }

    public Country Country { get; set; }

    public ICollection<User> Users { get; set; }
}
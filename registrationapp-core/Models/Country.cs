namespace registrationapp_core.Models;

public class Country
{
    public int Id { get; set; }

    public string Name { get; set; }

    public ICollection<CountryRegion> CountryRegions { get; set; }
}
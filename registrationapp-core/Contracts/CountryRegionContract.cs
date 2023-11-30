namespace registrationapp_core.Contracts;

public class CountryRegionContract
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int CountryId { get; set; }

    public CountryContract Country { get; set; }

    public ICollection<UserContract> Users { get; set; }
}
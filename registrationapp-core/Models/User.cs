namespace registrationapp_core.Models;

public class User
{
    public Guid Id { get; set; }

    public string Login { get; set; }

    public string Password { get; set; }

    public int CountryRegionId { get; set; }

    public CountryRegion CountryRegion { get; set; }
}

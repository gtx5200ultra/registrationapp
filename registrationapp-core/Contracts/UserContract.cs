namespace registrationapp_core.Contracts;

public class UserContract
{
    public Guid Id { get; set; }

    public string Login { get; set; }

    public int CountryRegionId { get; set; }

    public CountryRegionContract CountryRegion { get; set; }
}

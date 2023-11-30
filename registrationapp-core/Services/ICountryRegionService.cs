using registrationapp_core.Contracts;

namespace registrationapp_core.Services;

public interface ICountryRegionService
{
    Task<IEnumerable<CountryRegionContract>> GetCountryRegionsByCountry(int countryId);
}
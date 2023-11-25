using registrationapp_core.Models;

namespace registrationapp_core.Services;

public interface ICountryRegionService
{
    Task<IEnumerable<CountryRegion>> GetCountryRegionsByCountry(int countryId);
}
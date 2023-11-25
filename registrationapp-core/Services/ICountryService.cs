using registrationapp_core.Models;

namespace registrationapp_core.Services;

public interface ICountryService
{
    Task<IEnumerable<Country>> GetCountries();
}
using registrationapp_core.Contracts;
using registrationapp_core.Models;

namespace registrationapp_core.Repositories
{
    public interface ICountryRegionRepository : IRepository<CountryRegion>
    {
        Task<IEnumerable<CountryRegionContract>> GetProvincesByCountry(int countryId);
    }
}
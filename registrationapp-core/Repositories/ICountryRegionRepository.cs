using registrationapp_core.Models;

namespace registrationapp_core.Repositories
{
    public interface ICountryRegionRepository : IRepository<CountryRegion>
    {
        Task<IEnumerable<CountryRegion>> GetProvincesByCountry(int countryId);
    }
}
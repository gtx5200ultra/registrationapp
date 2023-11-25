using Microsoft.EntityFrameworkCore;
using registrationapp_core.Models;
using registrationapp_core.Repositories;

namespace registrationapp_data.Repositories
{
    public class CountryRegionRepository : Repository<CountryRegion>, ICountryRegionRepository
    {
        private readonly RepositoryDbContext _repositoryDbContext;

        public CountryRegionRepository(DbContext context) : base(context)
        {
            _repositoryDbContext = Context as RepositoryDbContext ?? throw new InvalidOperationException();
        }

        public async Task<IEnumerable<CountryRegion>> GetProvincesByCountry(int countryId)
        {
            return await _repositoryDbContext.CountryRegions.Where(x => x.CountryId == countryId).ToListAsync();
        }
    }
}
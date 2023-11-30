using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using registrationapp_core.Contracts;
using registrationapp_core.Models;
using registrationapp_core.Repositories;

namespace registrationapp_data.Repositories
{
    public class CountryRegionRepository : Repository<CountryRegion>, ICountryRegionRepository
    {
        private readonly RepositoryDbContext _repositoryDbContext;

        public CountryRegionRepository(DbContext context, IMapper mapper) : base(context, mapper)
        {
            _repositoryDbContext = Context as RepositoryDbContext ?? throw new InvalidOperationException();
        }

        public async Task<IEnumerable<CountryRegionContract>> GetProvincesByCountry(int countryId)
        {
            return await _repositoryDbContext.CountryRegions
                .Where(x => x.CountryId == countryId)
                .ProjectTo<CountryRegionContract>(_mapper.ConfigurationProvider).ToListAsync();
        }
    }
}
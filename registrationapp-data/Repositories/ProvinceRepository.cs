using Microsoft.EntityFrameworkCore;
using registrationapp_core.Models;
using registrationapp_core.Repositories;

namespace registrationapp_data.Repositories;

public class ProvinceRepository : Repository<Province>, IProvinceRepository
{
    private readonly RepositoryDbContext _repositoryDbContext;

    public ProvinceRepository(DbContext context) : base(context)
    {
        _repositoryDbContext = Context as RepositoryDbContext ?? throw new InvalidOperationException();
    }

    public async Task<IEnumerable<Province>> GetProvincesByCountry(int countryId)
    {
        return await _repositoryDbContext.Provinces.Where(x => x.CountryId == countryId).ToListAsync();
    }
}
using Microsoft.EntityFrameworkCore;
using registrationapp_core.Models;
using registrationapp_core.Repositories;

namespace registrationapp_data.Repositories;

public class CountryRepository : Repository<Country>, ICountryRepository
{
    public CountryRepository(DbContext context) : base(context)
    {
    }

    public Task<Country> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
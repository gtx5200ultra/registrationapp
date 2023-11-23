using registrationapp_core.Models;

namespace registrationapp_core.Repositories
{
    public interface ICountryRepository : IRepository<Country>
    {
        Task<Country> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
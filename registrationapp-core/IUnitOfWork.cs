using registrationapp_core.Repositories;

namespace registrationapp_core
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        ICountryRepository Countries { get; }
        IProvinceRepository Provinces { get; }
        Task<int> CommitAsync();
    }
}

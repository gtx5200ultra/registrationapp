using registrationapp_core.Repositories;

namespace registrationapp_core
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        ICountryRepository Countries { get; }
        Task<int> CommitAsync();
    }
}

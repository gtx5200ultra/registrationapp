using registrationapp_core;
using registrationapp_core.Repositories;
using registrationapp_data.Repositories;

namespace registrationapp_data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private UserRepository? _userRepository;
        private CountryRepository? _countryRepository;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IUserRepository Users => _userRepository ??= new UserRepository(_context);

        public ICountryRepository Countries => _countryRepository ??= new CountryRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
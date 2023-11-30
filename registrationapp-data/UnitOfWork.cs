using AutoMapper;
using registrationapp_core;
using registrationapp_core.Repositories;
using registrationapp_data.Repositories;

namespace registrationapp_data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RepositoryDbContext _context;
        private readonly IMapper _mapper;
        private UserRepository? _userRepository;
        private CountryRepository? _countryRepository;
        private CountryRegionRepository? _countryRegionRepository;

        public UnitOfWork(RepositoryDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IUserRepository Users => _userRepository ??= new UserRepository(_context, _mapper);

        public ICountryRepository Countries => _countryRepository ??= new CountryRepository(_context, _mapper);
        
        public ICountryRegionRepository CountryRegions => _countryRegionRepository ??= new CountryRegionRepository(_context, _mapper);

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
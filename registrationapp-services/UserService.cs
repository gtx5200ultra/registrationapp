using registrationapp_core;
using registrationapp_core.Models;
using registrationapp_core.Services;

namespace registrationapp_services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<User> CreateUser(User user)
        {
            _unitOfWork.CommitAsync();
            return null;
        }
    }

    public class CountryService : ICountryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CountryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Country>> GetCountries()
        {
            return await _unitOfWork.Countries.GetAllAsync();
        }
    }

    public class ProvinceService : IProvinceService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProvinceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Province>> GetProvincesByCountry(int countryId)
        {
            return await _unitOfWork.Provinces.GetProvincesByCountry(countryId);
        }
    }
}
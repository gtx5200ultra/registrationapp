using registrationapp_core;
using registrationapp_core.Contracts;
using registrationapp_core.Services;

namespace registrationapp_services;

public class CountryService : ICountryService
{
    private readonly IUnitOfWork _unitOfWork;

    public CountryService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<CountryContract>> GetCountries()
    {
        return await _unitOfWork.Countries.GetAllAsync<CountryContract>();
    }
}
using registrationapp_core;
using registrationapp_core.Models;
using registrationapp_core.Services;

namespace registrationapp_services;

public class CountryService : ICountryService
{
    private readonly IUnitOfWork _unitOfWork;

    public CountryService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Country>> GetCountries()
    {
        return await _unitOfWork.Countries.GetAllAsync<Country>();
    }
}
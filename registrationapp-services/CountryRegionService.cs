using registrationapp_core;
using registrationapp_core.Contracts;
using registrationapp_core.Models;
using registrationapp_core.Services;

namespace registrationapp_services;

public class CountryRegionService : ICountryRegionService
{
    private readonly IUnitOfWork _unitOfWork;

    public CountryRegionService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<CountryRegionContract>> GetCountryRegionsByCountry(int countryId)
    {
        return await _unitOfWork.CountryRegions.GetProvincesByCountry(countryId);
    }
}
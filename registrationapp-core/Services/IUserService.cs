﻿using registrationapp_core.Models;

namespace registrationapp_core.Services
{
    public interface IUserService
    {
        Task<User> CreateUser(User user);
    }

    public interface ICountryService
    {
        Task<IEnumerable<Country>> GetCountries();
    }

    public interface IProvinceService
    {
        Task<IEnumerable<Province>> GetProvincesByCountry(int countryId);
    }
}
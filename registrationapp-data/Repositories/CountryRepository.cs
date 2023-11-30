using AutoMapper;
using Microsoft.EntityFrameworkCore;
using registrationapp_core.Models;
using registrationapp_core.Repositories;

namespace registrationapp_data.Repositories
{
    public class CountryRepository : Repository<Country>, ICountryRepository
    {
        public CountryRepository(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
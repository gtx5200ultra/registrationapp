using registrationapp_core.Models;

namespace registrationapp_core.Repositories
{
    public interface IProvinceRepository : IRepository<Province>
    {
        Task<IEnumerable<Province>> GetProvincesByCountry(int countryId);
    }
}
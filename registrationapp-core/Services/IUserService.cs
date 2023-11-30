using registrationapp_core.Contracts;
using registrationapp_core.Models;

namespace registrationapp_core.Services
{
    public interface IUserService
    {
        Task<UserContract> CreateUser(User user);
    }
}
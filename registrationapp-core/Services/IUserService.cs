using registrationapp_core.Models;

namespace registrationapp_core.Services
{
    public interface IUserService
    {
        Task<User> CreateUser(User user);
    }
}
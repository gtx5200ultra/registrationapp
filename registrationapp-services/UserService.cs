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
}
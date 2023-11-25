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

        public async Task<User> CreateUser(User user)
        {
            if (await _unitOfWork.Users.AnyAsync(x => x.Login == user.Login))
            {
                throw new InvalidOperationException("User already exists");
            }

            await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.CommitAsync();
            return user;
        }
    }
}
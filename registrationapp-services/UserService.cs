using registrationapp_core;
using registrationapp_core.Contracts;
using registrationapp_core.Models;
using registrationapp_core.Services;
using registrationapp_services.Utils;

namespace registrationapp_services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICryptoHelper _cryptoHelper;

        public UserService(IUnitOfWork unitOfWork, ICryptoHelper cryptoHelper)
        {
            _unitOfWork = unitOfWork;
            _cryptoHelper = cryptoHelper;
        }

        public async Task<UserContract> CreateUser(User user)
        {
            if (await _unitOfWork.Users.AnyAsync(x => x.Login == user.Login))
            {
                throw new InvalidOperationException("User already exists");
            }

            user.Password = _cryptoHelper.EncryptString(user.Password);

            await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.CommitAsync();

            return new UserContract
            {
                Id = user.Id
            };
        }
    }
}
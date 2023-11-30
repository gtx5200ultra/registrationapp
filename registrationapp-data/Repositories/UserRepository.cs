using AutoMapper;
using Microsoft.EntityFrameworkCore;
using registrationapp_core.Models;
using registrationapp_core.Repositories;

namespace registrationapp_data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}

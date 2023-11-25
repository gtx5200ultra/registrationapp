using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RegistrationApp.DTO;
using registrationapp_core.Models;
using registrationapp_core.Services;

namespace RegistrationApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateUser([FromBody] UserDto dto)
        {
            var user = await _userService.CreateUser(_mapper.Map<User>(dto));
            return Ok(user);
        }
    }
}

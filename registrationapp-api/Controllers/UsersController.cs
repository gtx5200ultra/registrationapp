using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using registrationapp.DTO;
using registrationapp.Validators;
using registrationapp_core.Models;
using registrationapp_core.Services;

namespace registrationapp.Controllers
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
            var validator = new CreateUserValidator();
            var validationResult = await validator.ValidateAsync(dto);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.First().ErrorMessage);
            }

            var userDb = await _userService.CreateUser(_mapper.Map<User>(dto));
            var user = _mapper.Map<UserDto>(userDb);

            return Ok(user);
        }
    }
}

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
        public async Task<ActionResult> CreateUser([FromBody] UserDto dto)
        {
            var validator = new CreateUserValidator();
            var validationResult = await validator.ValidateAsync(dto);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.First().ErrorMessage);
            }

            var user = await _userService.CreateUser(_mapper.Map<User>(dto));
            return Ok(_mapper.Map<CreatedUserDto>(user));
        }
    }
}

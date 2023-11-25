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

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateUser([FromBody] UserDto dto)
        {
            var t = dto;
            //var countries = await _countryService.GetCountries();
            //var dto = _mapper.Map<Country, CountryDto>(countries);
            return Ok(new User());
        }
    }
}

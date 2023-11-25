using Microsoft.AspNetCore.Mvc;
using registrationapp_core.Models;
using registrationapp_core.Services;

namespace registrationapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountriesController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Country>>> GetAllProducts()
        {
            var countries = await _countryService.GetCountries();
            //var dto = _mapper.Map<Country, CountryDto>(countries);
            return Ok(countries);
        }
    }
}

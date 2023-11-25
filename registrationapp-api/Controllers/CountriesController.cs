using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using registrationapp.DTO;
using registrationapp_core.Services;

namespace registrationapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryService _countryService;
        private readonly IMapper _mapper;

        public CountriesController(ICountryService countryService, IMapper mapper)
        {
            _countryService = countryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllProducts()
        {
            var countries = await _countryService.GetCountries();
            return Ok(_mapper.Map<IEnumerable<CountryDto>>(countries));
        }
    }
}

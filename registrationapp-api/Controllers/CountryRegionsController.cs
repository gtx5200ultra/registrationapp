using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using registrationapp_core.Models;
using registrationapp_core.Services;

namespace registrationapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryRegionsController : ControllerBase
    {
        private readonly ICountryRegionService _countryRegionService;

        public CountryRegionsController(ICountryRegionService countryRegionService)
        {
            _countryRegionService = countryRegionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Country>>> GetCountryRegionsByCountry([FromQuery] ProvincesByCountryRequest request)
        {
            var countries = await _countryRegionService.GetCountryRegionsByCountry(request.CountryId);
            //var dto = _mapper.Map<Country, CountryDto>(countries);
            return Ok(countries);
        }
    }

    public class ProvincesByCountryRequest
    {
        [BindRequired]
        public int CountryId { get; set; }
    }
}

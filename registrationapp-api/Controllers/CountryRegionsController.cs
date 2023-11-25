using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using registrationapp.DTO;
using registrationapp_core.Services;

namespace registrationapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryRegionsController : ControllerBase
    {
        private readonly ICountryRegionService _countryRegionService;
        private readonly IMapper _mapper;

        public CountryRegionsController(ICountryRegionService countryRegionService, IMapper mapper)
        {
            _countryRegionService = countryRegionService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetCountryRegionsByCountry([FromQuery] ProvincesByCountryDto request)
        {
            var countryRegions = await _countryRegionService.GetCountryRegionsByCountry(request.CountryId);
            return Ok(_mapper.Map<IEnumerable<CountryRegionDto>>(countryRegions));
        }
    }


}

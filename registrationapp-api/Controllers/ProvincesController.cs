﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using registrationapp_core.Models;
using registrationapp_core.Services;

namespace RegistrationApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvincesController : ControllerBase
    {
        private readonly IProvinceService _provinceService;

        public ProvincesController(IProvinceService provinceService)
        {
            _provinceService = provinceService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Country>>> GetProvincesByCountry([FromQuery] ProvincesByCountryRequest request)
        {
            var countries = await _provinceService.GetProvincesByCountry(request.CountryId);
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

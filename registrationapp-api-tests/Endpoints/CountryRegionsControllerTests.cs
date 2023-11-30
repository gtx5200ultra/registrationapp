using Moq;
using AutoMapper;
using registrationapp.Controllers;
using registrationapp_core.Services;
using Microsoft.AspNetCore.Mvc;
using registrationapp_core.Models;
using registrationapp.Mapping;
using Microsoft.AspNetCore.Http;
using registrationapp.DTO;

namespace registrationapp_api_tests.Endpoints
{
    [TestClass]
    public class CountryRegionsControllerTests
    {
        private readonly CountryRegionsController _controller;

        public CountryRegionsControllerTests()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            var mapper = mappingConfig.CreateMapper();

            Mock<ICountryRegionService> mockCountryRegionService = new();

            mockCountryRegionService.Setup(repo => repo.GetCountryRegionsByCountry(It.IsAny<int>()))
                .ReturnsAsync(new List<CountryRegion> { new () });

            _controller = new CountryRegionsController(mockCountryRegionService.Object, mapper);
        }

        [TestMethod]
        public async Task GetCountryRegionsByCountry_Valid()
        {
            var result = await _controller.GetCountryRegionsByCountry(new ProvincesByCountryDto
            {
                CountryId = 1
            }) as OkObjectResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(StatusCodes.Status200OK, result.StatusCode);
            Assert.IsNotNull(result.Value);
        }
    }
}

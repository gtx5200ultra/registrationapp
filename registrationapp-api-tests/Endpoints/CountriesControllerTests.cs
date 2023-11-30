using Moq;
using AutoMapper;
using registrationapp.Controllers;
using registrationapp_core.Services;
using Microsoft.AspNetCore.Mvc;
using registrationapp_core.Models;
using registrationapp.Mapping;
using Microsoft.AspNetCore.Http;
using registrationapp_core.Contracts;

namespace registrationapp_api_tests.Endpoints
{
    [TestClass]
    public class CountriesControllerTests
    {
        private readonly CountriesController _controller;

        public CountriesControllerTests()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            var mapper = mappingConfig.CreateMapper();

            Mock<ICountryService> mockCountryService = new();

            mockCountryService.Setup(repo => repo.GetCountries())
                .ReturnsAsync(new List<CountryContract> { new () });

            _controller = new CountriesController(mockCountryService.Object, mapper);
        }

        [TestMethod]
        public async Task GetAllProducts_Valid()
        {
            var result = await _controller.GetAllProducts() as OkObjectResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(StatusCodes.Status200OK, result.StatusCode);
            Assert.IsNotNull(result.Value);
        }
    }
}

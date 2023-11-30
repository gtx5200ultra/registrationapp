using Moq;
using AutoMapper;
using registrationapp.Controllers;
using Microsoft.AspNetCore.Mvc;
using registrationapp.Mapping;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using registrationapp.DTO;
using registrationapp_data;
using registrationapp_services;
using registrationapp_services.Utils;

namespace registrationapp_api_tests.Endpoints
{
    [TestClass]
    public class UsersControllerTests
    {
        private readonly UsersController _controller;

        public UsersControllerTests()
        {
            var options = new DbContextOptionsBuilder<RepositoryDbContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryDatabase" + Guid.NewGuid())
                .Options;

            var unitOfWork = new UnitOfWork(new RepositoryDbContext(options));

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            var mapper = mappingConfig.CreateMapper();

            Mock<ICryptoHelper> mockCryptoHelper = new();

            mockCryptoHelper.Setup(i => i.EncryptString(It.IsAny<string>()))
                .Returns(Guid.NewGuid().ToString);

            _controller = new UsersController(new UserService(unitOfWork, mockCryptoHelper.Object), mapper);
        }

        [TestMethod]
        public async Task CreateUser_Invalid()
        {
            var result = await _controller.CreateUser(new UserDto
            {
                Login = $"{Guid.NewGuid()}.com",
                Password = "ABC123",
                CountryRegionId = 1
            }) as BadRequestObjectResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(StatusCodes.Status400BadRequest, result.StatusCode);
            Assert.AreEqual((string)result.Value!, "'Login' is not in the correct format");
        }

        [TestMethod]
        public async Task CreateUser_Valid()
        {
            var result = await _controller.CreateUser(new UserDto
            {
                Login = $"{Guid.NewGuid()}@{Guid.NewGuid()}.com",
                Password = "A123",
                CountryRegionId = 1
            }) as OkObjectResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(StatusCodes.Status200OK, result.StatusCode);
            Assert.IsNotNull(result.Value);
        }
    }
}

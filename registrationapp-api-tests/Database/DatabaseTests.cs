using AutoMapper;
using Microsoft.EntityFrameworkCore;
using registrationapp.DTO;
using registrationapp.Mapping;
using registrationapp_core.Models;
using registrationapp_data;

namespace registrationapp_api_tests.Database
{
    [TestClass]
    public class DatabaseTests
    {
        private UnitOfWork _unitOfWork = null!;

        [TestInitialize]
        public void Initialize()
        {
            var options = new DbContextOptionsBuilder<RepositoryDbContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryDatabase")
                .Options;

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            var mapper = mappingConfig.CreateMapper();

            _unitOfWork = new UnitOfWork(new RepositoryDbContext(options), mapper);
        }

        [TestMethod]
        public async Task CreateUser_Success()
        {
            var user = new User
            {
                Login = "test",
                Password = "test"
            };

            await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.CommitAsync();

            var result = await _unitOfWork.Users.FindAsync<CreatedUserDto>(x => x.Id == user.Id);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task CreateCountries_Success()
        {
            var countries = new Country[]
            {
                new() {
                    Id = 1,
                    Name = "Test 1",
                    CountryRegions = new List<CountryRegion>
                    {
                        new()
                        {
                            Name = "Region 1.1"
                        },
                        new()
                        {
                            Name = "Region 1.2"
                        }
                    }
                },
                new() {
                    Id = 2,
                    Name = "Test 2",
                    CountryRegions = new List<CountryRegion>
                    {
                        new()
                        {
                            Name = "Region 2.1"
                        },
                        new()
                        {
                            Name = "Region 2.2"
                        }
                    }
                }
            };

            await _unitOfWork.Countries.AddRangeAsync(countries);
            await _unitOfWork.CommitAsync();

            var result = await _unitOfWork.Countries.GetAllAsync<CountryDto>();

            Assert.AreEqual(result.Count(), 2);
        }

        [TestMethod]
        public async Task CreateUserTwiceThrowsException()
        {
            var user = new User
            {
                Login = "test",
                Password = "test"
            };

            await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.CommitAsync();

            await _unitOfWork.Users.AddAsync(user);
            await Assert.ThrowsExceptionAsync<ArgumentException>(async () => await _unitOfWork.CommitAsync());
        }
    }
}
using System.Net.Http.Json;
using System.Text;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using registrationapp;
using registrationapp.DTO;

namespace registrationapp_web_tests
{
    public class WebTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _server;

        public WebTests(WebApplicationFactory<Program> server)
        {
            _server = server;
        }

        [Fact]
        public async Task ApiCountries_GetCountries()
        {
            var client = _server.CreateClient();
            var response = await client.GetAsync("/api/Countries");
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadFromJsonAsync<IEnumerable<CountryDto>>();

            Assert.NotNull(responseContent);
            Assert.NotEmpty(responseContent);
        }

        [Fact]
        public async Task ApiCountryRegions_GetCountryRegionsByCountry()
        {
            var client = _server.CreateClient();
            var response = await client.GetAsync("/api/CountryRegions?countryId=1");
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadFromJsonAsync<IEnumerable<CountryRegionDto>>();

            Assert.NotNull(responseContent);
            Assert.NotEmpty(responseContent);
        }

        [Fact]
        public async Task ApiUsers_CreateUser()
        {
            using StringContent jsonContent = new(
                JsonConvert.SerializeObject(new UserDto
                {
                    Login = $"{Guid.NewGuid()}@test.com",
                    CountryRegionId = 1,
                    Password = "ABC123"
                }),
                Encoding.UTF8,
                "application/json");

            var client = this._server.CreateClient(new WebApplicationFactoryClientOptions { AllowAutoRedirect = false });
            var response = await client.PostAsync("/api/Users", jsonContent);

            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadFromJsonAsync<CreatedUserDto>();

            Assert.NotNull(responseContent);
        }
    }
}
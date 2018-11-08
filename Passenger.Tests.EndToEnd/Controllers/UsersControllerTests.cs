using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using NUnit.Framework;
using Passenger.Api;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Passenger.Infrastructure.DTO;
using System.Net;
using System.Text;
using Passenger.Infrastructure.Commands.User;

namespace Passenger.Tests.EndToEnd.Controllers
{
    [TestFixture]
    public class UsersControllerTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public UsersControllerTests()
        {
            // Arrange
            _server = new TestServer(new WebHostBuilder()
               .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Test]
        public async Task Given_valid_email_user_should_exists()
        {
            
            // Arrange
            var email = "user1@tmp.pl";

            // Act
            var user = await GetUserDtoAsync(email);

            // Assert
            Assert.AreEqual(user.Email ,email);
        }

        [Test]
        public async Task Given_invalid_email_user_should_not_exists()
        {
            // Arrange
            var email = "user5@tmp.pl";

            // Act
            var response = await _client.GetAsync($"users/{email}");
            
            // Assert
            Assert.AreEqual(response.StatusCode, HttpStatusCode.NotFound);
        }

        [Test]
        public async Task Given_invalid_email_user_should_be_created()
        {
            // Arrange
            var request = new CreateUser
            {
                Email = "testuser@tmp.pl",
                Username = "testuser",
                Password = "password123@"
            };

            // Act
            var payload = GetPayload(request);
            var response = await _client.PostAsync($"users",payload);

            // Assert
            Assert.AreEqual(response.StatusCode, HttpStatusCode.Created);
            Assert.AreEqual(response.Headers.Location.OriginalString, $"users/{request.Email}");
            /*
            var user = await GetUserDtoAsync(request.Email);
            Assert.AreEqual(user.Email, request.Email); */
        }

        private async Task<UserDto> GetUserDtoAsync(string email)
        {
            var response = await _client.GetAsync($"users/{email}");
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<UserDto>(responseString);
        }

        private static StringContent GetPayload(object data)
        {
            var json = JsonConvert.SerializeObject(data);

            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}

using NUnit.Framework;
using Passenger.Api;
using Passenger.Infrastructure.Commands.Users;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Passenger.Tests.EndToEnd.Controllers
{
    public class AccountControllerTests : ControllerTestsBase
    {
        [Test]
        public async Task Given_valid_current_and_new_password_it_should_be_change()
        {
            // Arrange
            var command = new ChangeUserPassword
            {
                CurrentPassword = "password123@",
                NewPassword = "12345@password"
        };

            // Act
            var payload = GetPayload(command);
            var response = await Client.PutAsync($"account/password", payload);

            // Assert
            Assert.AreEqual(response.StatusCode, HttpStatusCode.NoContent);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using NUnit.Framework;
using Passenger.Core.Domain;
using Passenger.Core.Repositories;
using Passenger.Infrastructure.Services;

namespace Passenger.Tests.Service
{
    [TestFixture]
    public class UserServiceTests
    {
        [SetUp]
        public void Setup()
        {
            //
        }

        [Test]
        public async Task Register_async_should_bt_invoke_add_async_on_repository()
        {
            //Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();
            var userService = new UserService(userRepositoryMock.Object, mapperMock.Object);

            //Act
            await userService.RegisterAsync("user@email.com","user", "password123@");

            //Assert
            userRepositoryMock.Verify(x => x.AddAsync(It.IsAny<User>()),Times.Once);
        }
    }
}

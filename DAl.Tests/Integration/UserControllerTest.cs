using DAL.Entities;
using LibraryInformationSystem.LibraryInformationSystem.BLL.DTOs.User;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace DAl.Tests.Integration
{
    public class UserControllerTest : IntegrationTestsBase
    {
        public UserControllerTest(CustomWebApplicationFactory<Program> factory) : base(factory)
        {
        }

        [Fact]
        public async Task POST_CreateUser_ValidObject_ReturnsOK()
        {
            // Arrange
            UserCreateDTO request = new UserCreateDTO
            {
                Name = "name",
                Email = "email@gmail.com",
                PhoneNumber = "1234567890",
            };

            // Act
            var response = await client.PostAsJsonAsync("api/user", request);

            // Assert
            Assert.Equal(response.StatusCode, System.Net.HttpStatusCode.OK);
        }

        [Fact]
        public async Task POST_CreateInvalidUser_ReturnsBadRequest()
        {
            // Arrange
            UserCreateDTO request = null;

            // Act
            var response = await client.PostAsJsonAsync("api/user", request);

            // Assert
            Assert.Equal(response.StatusCode, System.Net.HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task GET_User_ReturnsOK()
        {
            // Arrange

            // Act
            var response = await client.GetAsync($"api/user");

            // Assert
            Assert.Equal(response.StatusCode, System.Net.HttpStatusCode.OK);
        }

        [Fact]
        public async Task GET_UserByValidId_ReturnsOK()
        {
            // Arrange
            User request = new()
            {
                Name = "name",
                Email = "email@gmail.com",
                PhoneNumber = "1234567890",
            };
            await context.Users.AddAsync(request);
            context.SaveChanges();
            var id = context.Users.FirstOrDefault().Id;

            // Act
            var response = await client.GetAsync($"api/user/{id}");

            // Assert
            Assert.Equal(response.StatusCode, System.Net.HttpStatusCode.OK);
        }

        [Fact]
        public async Task GET_UserByInValidId_ReturnsBadRequest()
        {
            // Arrange
            long id = -1;

            // Act
            var response = await client.GetAsync($"api/user/{id}");

            // Assert
            Assert.Equal(response.StatusCode, System.Net.HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Delete_ReturnsOk()
        {
            // Arrange
            long id = 1;

            // Act
            var response = await client.DeleteAsync($"api/user/{id}");

            // Assert
            Assert.Equal(response.StatusCode, System.Net.HttpStatusCode.OK);
        }

        [Fact]
        public async Task GET_UserByValidName_ReturnsOK()
        {
            // Arrange
            User request = new()
            {
                Name = "name",
                Email = "email@gmail.com",
                PhoneNumber = "1234567890",
            };
            await context.Users.AddAsync(request);
            context.SaveChanges();

            // Act
            var response = await client.GetAsync($"api/user/byName/{request.Name}");

            // Assert
            Assert.Equal(response.StatusCode, System.Net.HttpStatusCode.OK);
        }

        [Fact]
        public async Task GET_UserByInValidName_ReturnsBadRequest()
        {
            // Arrange
            User request = new()
            {
                Name = "name",
                Email = "email@gmail.com",
                PhoneNumber = "1234567890",
            };
            await context.Users.AddAsync(request);
            context.SaveChanges();

            // Act
            var response = await client.GetAsync($"api/user/byName/{request.Name + Guid.NewGuid().ToString()}");

            // Assert
            Assert.Equal(response.StatusCode, System.Net.HttpStatusCode.BadRequest);
        }
    }
}

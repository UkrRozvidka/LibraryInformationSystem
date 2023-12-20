using DAL.Entities;
using LibraryInformationSystem.BLL.DTOs.Borrow;
using LibraryInformationSystem.LibraryInformationSystem.BLL.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace DAl.Tests.Integration
{
    public class BorrowControllerTest : IntegrationTestsBase
    {
        public BorrowControllerTest(CustomWebApplicationFactory<Program> factory) : base(factory)
        {
        }

        //[Fact]
        //public async Task POST_CreateBorrow_ValidObject_ReturnsOK()
        //{
        //    // Arrange
        //    User user = new()
        //    {
        //        Name = "name",
        //        Email = "email@gmail.com",
        //        PhoneNumber = "1234567890",
        //    };
        //    await context.Users.AddAsync(user);
        //    Book book = new()
        //    {
        //        Title = "title",
        //        Author = "author",
        //        PublishedYear = 2003,
        //        GenreId = 1
        //    };
        //    await context.Books.AddAsync(book);
        //    context.SaveChanges();

        //    BorrowCreateDTO request = new ()
        //    {
        //        UserId = 1,
        //        BookId = 1,
        //    };

        //    // Act
        //    var response = await client.PostAsJsonAsync("api/borrow", request);

        //    // Assert
        //    Assert.Equal(response.StatusCode, System.Net.HttpStatusCode.OK);
        //}

        //[Fact]
        //public async Task POST_CreateBorrow_InValidId_ReturnsBadRequest()
        //{

        //    // Arrange
        //    context.Borrows.RemoveRange();
        //    context.Books.RemoveRange();
        //    context.Users.RemoveRange();
        //    context.SaveChanges();
        //    BorrowCreateDTO request = new()
        //    {
        //        UserId = 1,
        //        BookId = 1,
        //    };

        //    // Act
        //    var response = await client.PostAsJsonAsync("api/borrow", request);

        //    // Assert
        //    Assert.Equal(response.StatusCode, System.Net.HttpStatusCode.BadRequest);
        //}

        [Fact]
        public async Task POST_CreateBorrow_NullId_ReturnsBadRequest()
        {
            // Arrange
            User user = new()
            {
                Name = "name",
                Email = "email@gmail.com",
                PhoneNumber = "1234567890",
            };
            await context.Users.AddAsync(user);
            Book book = new()
            {
                Title = "title",
                Author = "author",
                PublishedYear = 2003,
                GenreId = 1
            };
            await context.Books.AddAsync(book);
            context.SaveChanges();
            BorrowCreateDTO request = new()
            {
                BookId = 1,
            };

            // Act
            var response = await client.PostAsJsonAsync("api/borrow", request);

            // Assert
            Assert.Equal(response.StatusCode, System.Net.HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task POST_CreateBorrow_NullPassed_ReturnsBadRequest()
        {
            // Arrange
            BorrowCreateDTO request = null;

            // Act
            var response = await client.PostAsJsonAsync("api/borrow", request);

            // Assert
            Assert.Equal(response.StatusCode, System.Net.HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task GET_Borrows_ReturnsOK()
        {
            // Arrange

            // Act
            var response = await client.GetAsync($"api/borrow");

            // Assert
            Assert.Equal(response.StatusCode, System.Net.HttpStatusCode.OK);
        }

        //[Fact]
        //public async Task Put_ValidData_ReturnsOk()
        //{
        //    // Arrange
        //    User user = new()
        //    {
        //        Name = "name",
        //        Email = "email@gmail.com",
        //        PhoneNumber = "1234567890",
        //    };
        //    await context.Users.AddAsync(user);
        //    Book book = new()
        //    {
        //        Title = "title",
        //        Author = "author",
        //        PublishedYear = 2003,
        //        GenreId = 1
        //    };
        //    await context.Books.AddAsync(book);
        //    context.SaveChanges();

        //    Borrow borrow = new()
        //    {
        //        UserId = 1,
        //        BookId = 1,
        //        StatusId = 1,
        //        BorrowDate = DateTime.Now
        //    };
        //    await context.Borrows.AddAsync(borrow);
        //    context.SaveChanges();

        //    BorrowUpdateDto update = new() { StatusId = 2 };

        //    // Act
        //    var response = await client.PutAsJsonAsync($"api/borrow/{(long)1}", update);

        //    // Assert
        //    Assert.Equal(response.StatusCode, System.Net.HttpStatusCode.OK);
        //}

        //[Fact]
        //public async Task GET_BorrowByValidId_ReturnsOK()
        //{
        //    //Arrange
        //       User user = new()
        //       {
        //           Name = "name",
        //           Email = "email@gmail.com",
        //           PhoneNumber = "1234567890",
        //       };
        //    await context.Users.AddAsync(user);
        //    Book book = new()
        //    {
        //        Title = "title",
        //        Author = "author",
        //        PublishedYear = 2003,
        //        GenreId = 1
        //    };
        //    await context.Books.AddAsync(book);
        //    context.SaveChanges();

        //    Borrow borrow = new()
        //    {
        //        UserId = 1,
        //        BookId = 1,
        //        StatusId = 1,
        //        BorrowDate = DateTime.Now
        //    };
        //    await context.Borrows.AddAsync(borrow);
        //    context.SaveChanges();
        //    var id = context.Borrows.FirstOrDefault().Id;

        //    // Act
        //    var response = await client.GetAsync($"api/borrow/{id}");

        //    // Assert
        //    Assert.Equal(response.StatusCode, System.Net.HttpStatusCode.OK);
        //}

        [Fact]
        public void GET_BorowByInValidId_ReturnsBadRequest()
        {
            // Arrange
            long id = -1;

            // Act
            var response = client.GetAsync($"api/user/{id}");

            // Assert
            Assert.Equal(response.StatusCode, System.Net.HttpStatusCode.BadRequest);
        }
    }
}

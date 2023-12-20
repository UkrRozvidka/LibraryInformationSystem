using AutoMapper;
using BLL.Services;
using BLL.Services.Contracts;
using DAL.Entities;
using LibraryInformationSystem.BLL.DTOs.Book;
using LibraryInformationSystem.BLL.DTOs.Borrow;
using LibraryInformationSystem.LibraryInformationSystem.BLL.DTOs.Book;
using LibraryInformationSystem.LibraryInformationSystem.BLL.DTOs.User;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace DAl.Tests
{
    public class BookServiceTest : RepositoryMoq
    {
        private IBookService _bookService;

        public BookServiceTest()
        {
            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(m => m.Map<BookGetDTO>(It.IsAny<Book>()))
            .Returns((Book book) => new BookGetDTO
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                GenreId = book.GenreId,
                GenreName = book.Genre?.Name,
                PublishedYear = book.PublishedYear,
                Count = book.Count
            });
            _bookService = new BookService(mapperMock.Object, _bookRepository,
                _borrowRepository, _genreRepository);
        }

        [Fact]
        public async Task GetAll_ShoudGetManyElenent()
        {
            var booksRepo = await _bookRepository.GetAllAsync();
            var booksRepoList = booksRepo.ToList();

            // Act
            var books = await _bookService.GetAll();
            var booksList = books.ToList();
            // Assert
            Assert.NotNull(booksList);
            Assert.Equal(booksRepoList.Count, booksList.Count);

            for (int i = 0; i < booksRepoList.Count; i++)
            {
                Assert.Equal(booksRepoList[i].Id, booksList[i].Id);
                Assert.Equal(booksRepoList[i].Title, booksList[i].Title);
                Assert.Equal(booksRepoList[i].Author, booksList[i].Author);
                Assert.Equal(booksRepoList[i].PublishedYear, booksList[i].PublishedYear);
                Assert.Equal(booksRepoList[i].GenreId, booksList[i].GenreId);
                Assert.Equal(booksRepoList[i].Count, booksList[i].Count);
            }
        }

        [Fact]
        public async Task GetById_ShoudGetOneElenent()
        {
            // Arrange
            var addedBook = new Book
            {
                Title = "Title",
                Author = "Author",
                PublishedYear = 2010,
                GenreId = 1,
                Count = 1
            };
            var bookid = await _bookRepository.AddAsync(addedBook);
            var bookRepo = await _bookRepository.GetByIdAsync(bookid);

            // Act

            var user = await _bookService.GetById(bookid);

            // Assert
            Assert.Equal(bookid, user.Id);
            Assert.Equal(bookRepo.Title, user.Title);
            Assert.Equal(bookRepo.Author, user.Author);
            Assert.Equal(bookRepo.PublishedYear, user.PublishedYear);
            Assert.Equal(bookRepo.GenreId, user.GenreId);
            Assert.Equal(bookRepo.Count, user.Count);
        }

        [Fact]
        public async Task Delete_ShouldRemoveBook()
        {
            // Arrange
            var book = await _bookRepository.GetByIdAsync(1);

            // Act
            await _bookService.Delete(book.Id);

            // Assert
            var deletedUser = await _bookRepository.GetByIdAsync(book.Id);
            Assert.Null(deletedUser);
        }

        [Fact]
        public async Task UpdateAsync_ShoudUpdateCount()
        {
            // Arrange
            var addedBook = new Book
            {
                Title = "Title",
                Author = "Author",
                PublishedYear = 2010,
                GenreId = 1,
                Count = 1
            };
            var bookid = await _bookRepository.AddAsync(addedBook);
            var bookRepo = await _bookRepository.GetByIdAsync(bookid);
            var dto = new BookUpdateDTO { Count = 3 };

            // Act
            await _bookService.Update(bookid, dto);

            // Assert
            bookRepo = await _bookRepository.GetByIdAsync(bookid);
            Assert.Equal(bookRepo.Count, dto.Count);
        }

    }
}

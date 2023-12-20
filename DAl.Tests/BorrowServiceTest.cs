using AutoMapper;
using BLL.Services.Contracts;
using BLL.Services;
using DAL.Entities;
using LibraryInformationSystem.LibraryInformationSystem.BLL.DTOs.User;
using Moq;
using LibraryInformationSystem.BLL.DTOs.Borrow;

namespace DAl.Tests
{
    public class BorrowServiceTest : RepositoryMoq
    {
        private IBorrowService _borrowService;

        public BorrowServiceTest()
        {
            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(m => m.Map<BorrowGetDTO>(It.IsAny<Borrow>()))
            .Returns((Borrow borrow) => new BorrowGetDTO
            {
                Id = borrow.Id,
                UserId = borrow.UserId,
                BookId = borrow.BookId,
                BorrowDate = borrow.BorrowDate,
                ReturnDate = borrow.ReturnDate,
                StatusId = borrow.StatusId
            });
            mapperMock.Setup(m => m.Map<Borrow>(It.IsAny<BorrowCreateDTO>()))
            .Returns((BorrowCreateDTO dto) => new Borrow
            {
                UserId = dto.UserId,
                BookId = dto.BookId,
            });

            _borrowService = new BorrowService(mapperMock.Object, _borrowRepository,
                _userRepository, _bookRepository, _statusRepository);
        }

        [Fact]
        public async Task GetByIdAsync_ShoudGetOneElenent()
        {
            // Arrange
            var borrowid = await _borrowRepository.AddAsync(GetTestBorrow());
            var borrowRepo = await _borrowRepository.GetByIdAsync(borrowid);

            // Act
            var borrow = await _borrowService.GetByIdAsync(borrowid);

            // Assert
            Assert.Equal(borrowid, borrow.Id);
            Assert.Equal(borrowRepo.BookId, borrow.BookId);
            Assert.Equal(borrowRepo.UserId, borrow.UserId);
        }

        [Fact]
        public async Task Create_ShouldAddUser()
        {
            // Arrange
            var borrowCreateDTO = new BorrowCreateDTO
            {
                BookId = 1,
                UserId = 3
            };

            // Act
            var borrowId = await _borrowService.CreateAsync(borrowCreateDTO);

            var borrowFound = await _borrowService.GetByIdAsync(borrowId);
            

            // Assert
            Assert.Equal(borrowFound.BookId , borrowCreateDTO.BookId);
            Assert.Equal(borrowFound.UserId, borrowCreateDTO.UserId);
        }

        [Fact]
        public async Task GetAllAsync_ShoudGetManyElenent()
        {
            // Arrange
            var borrowsRepo = await _borrowRepository.GetAllAsync();
            var borrowsRepoList = borrowsRepo.ToList();

            // Act
            var borrows = await _borrowService.GetAllAsync();
            var borrowsList = borrows.ToList();
            // Assert
            Assert.NotNull(borrowsList);
            Assert.Equal(borrowsRepoList.Count, borrowsList.Count);

            for (int i = 0; i < borrowsRepoList.Count; i++)
            {
                Assert.Equal(borrowsRepoList[i].Id, borrowsList[i].Id);
                Assert.Equal(borrowsRepoList[i].BookId, borrowsList[i].BookId);
                Assert.Equal(borrowsRepoList[i].UserId, borrowsList[i].UserId);
                Assert.Equal(borrowsRepoList[i].BorrowDate, borrowsList[i].BorrowDate);
            }
        }

        [Fact]
        public async Task UpdateAsync_ShoudUpdateStatusId()
        {
            // Arrange
            var borrowid = await _borrowRepository.AddAsync(GetTestBorrow());
            var borrowRepo = await _borrowRepository.GetByIdAsync(borrowid);
            var dto = new BorrowUpdateDto { StatusId = 3 };

            // Act
            await _borrowService.UpdateaAsync(borrowid, dto);

            // Assert
            borrowRepo = await _borrowRepository.GetByIdAsync(borrowid);
            Assert.Equal(borrowRepo.StatusId, dto.StatusId);
        }

        private Borrow GetTestBorrow()
        {
            return new Borrow
            {
                UserId = 1,
                BookId = 3, 

            };
        }
    }
}

using AutoMapper;
using BLL.Services;
using BLL.Services.Contracts;
using DAL.Entities;
using LibraryInformationSystem.LibraryInformationSystem.BLL.DTOs.User;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;


namespace DAl.Tests
{
    public class UserServiceTest : RepositoryMoq
    {
        private IUserService _userService;

        public UserServiceTest()
        {
            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(m => m.Map<UserGetDTO>(It.IsAny<User>()))
            .Returns((User source) => new UserGetDTO
            {
                Id = source.Id,
                Name = source.Name,
                Email = source.Email,
                PhoneNumber = source.PhoneNumber
            });
            mapperMock.Setup(m => m.Map<User>(It.IsAny<UserCreateDTO>()))
            .Returns((UserCreateDTO dto) => new User
            {
                Name = dto.Name,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber
            });

            _userService = new UserService(mapperMock.Object, _userRepository,
                _borrowRepository, _bookRepository, _genreRepository);
        }

        [Fact]
        public async Task GetByIdAsync_ShoudGetOneElenent()
        {
            // Arrange
            var userid = await _userRepository.AddAsync(GetTestUser());
            var userRepo = await _userRepository.GetByIdAsync(userid);

            // Act

            var user = await _userService.GetByIdAsync(userid);

            // Assert
            Assert.Equal(userid, user.Id);
            Assert.Equal(userRepo.Name, user.Name);
            Assert.Equal(userRepo.Email, user.Email);
            Assert.Equal(userRepo.PhoneNumber, user.PhoneNumber);
        }

        [Fact]
        public async Task GetAllAsync_ShoudGetManyElenent()
        {
            var usersRepo = await _userRepository.GetAllAsync();
            var usersRepoList = usersRepo.ToList();

            // Act
            var users = await _userService.GetAllAsync();
            var usersList = users.ToList();
            // Assert
            Assert.NotNull(usersList);
            Assert.Equal(usersRepoList.Count, usersList.Count);

            for (int i = 0; i < usersRepoList.Count; i++)
            {
                Assert.Equal(usersRepoList[i].Id, usersList[i].Id);
                Assert.Equal(usersRepoList[i].Name, usersList[i].Name);
                Assert.Equal(usersRepoList[i].Email, usersList[i].Email);
                Assert.Equal(usersRepoList[i].PhoneNumber, usersList[i].PhoneNumber);
            }
        }

        [Fact]
        public async Task Create_ShouldAddUser()
        {
            // Arrange
            var userCreateDTO = new UserCreateDTO
            {
                Name = "John Doe",
                Email = "john.doe@example.com",
                PhoneNumber = "123456789"
            };

            // Act
            var userId = await _userService.Create(userCreateDTO);

            var userFound = await _userService.GetByIdAsync(userId);
            

            // Assert
            Assert.Equal(userFound.Name , userCreateDTO.Name);
            Assert.Equal(userFound.Email, userCreateDTO.Email);
            Assert.Equal(userFound.PhoneNumber, userCreateDTO.PhoneNumber);
        }

        [Fact]
        public async Task Delete_ShouldRemoveUser()
        {
            // Arrange
            var userCreateDTO = new UserCreateDTO
            {
                Name = "Test User",
                Email = "test.user@example.com",
                PhoneNumber = "987654321"
            };

            var userId = await _userService.Create(userCreateDTO);

            // Act
            await _userService.Delete(userId);

            // Assert
            var deletedUser = await _userRepository.GetByIdAsync(userId);
            Assert.Null(deletedUser);
        }


        public User GetTestUser()
        {
            return new User
            {
                Name = "name test",
                Email = "test@gamil.com",
                PhoneNumber = "1234567890"
            };
        }
    }
}

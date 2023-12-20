using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.EntityFrameworkCore;
using DAL.Context;
using DAL.Entities;
using DAL.Repository;
using System.Numerics;
using System.Net.WebSockets;
using System.Linq.Expressions;
using DAL.Repository.Contracts;

namespace DAl.Tests
{
    public class GenericRepositoryTests : ContextMoq
    {
        protected readonly IGenericRepository<User> repository;

        public GenericRepositoryTests() 
        {
            repository = new GenericRepository<User>(context);
        }

        [Fact]
        public async Task AddAsync_AddNewEntity_EntityIsPresendInTheDataSource()
        {
            // Arrange
            var entityToInsert = GetTestUser();

            // Act
            await repository.AddAsync(entityToInsert);

            var insertedEntity = context.Users.FirstOrDefault(x => x.Id == entityToInsert.Id);

            // Assert
            Assert.NotNull(insertedEntity);
            Assert.Equal(entityToInsert.Id, insertedEntity.Id);
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsOneEntity()
        {
            // Arrange
            var userId = await repository.AddAsync(GetTestUser());  

            // Act
            var user = await repository.GetByIdAsync(userId);

            // Assert
            Assert.NotNull(user);
            Assert.Equal(userId, user.Id);
        }

        [Fact]
        public async Task UpdateAsync_ShouldUpdateObject()
        {
            // Arrange
            var userId = await repository.AddAsync(GetTestUser());
            var existantUser = await repository.GetByIdAsync(userId);

            string newName = $"{existantUser.Name}-new";
            existantUser.Name = newName;

            // Act
            await repository.UpdateAsync(existantUser);

            var updatedUser = context.Users.FirstOrDefault(x => x.Id == existantUser.Id);

            // Assert
            Assert.NotNull(updatedUser);
            Assert.Equal(newName, updatedUser.Name);
        }

        [Fact]
        public async Task DeleteAsync_DeleteObject()
        {
            // Arrange
            var userId = await repository.AddAsync(GetTestUser());

            // Act
            await repository.DeleteAsync(userId);

            // Assert
            Assert.Null(context.Users.FirstOrDefault(u => u.Id == userId));
        }

        [Fact]
        public async Task GetAll_ShoudReturnAllObjects()
        {
            // Arrange
            var usersContext = context.Users.ToList();

            // Act
            var users = await repository.GetAllAsync();

            // Assert
            Assert.Equal(usersContext, users);
        }

        [Fact]
        public async Task GetOneWithFilter_ShoudReturnOneObject()
        {
            // Arrange
            Expression<Func<User, bool>> predicate = x => x.Name == "name test";
            var userContext = context.Users.FirstOrDefault(predicate);

            // Act
            var user = await repository.GetOneWithFilterAsync(predicate);

            // Assert
            Assert.Equal(userContext, user);

        }

        [Fact]
        public async Task GetManyWithFilter_ShoudReturnManyObject()
        {
            // Arrange
            Expression<Func<User, bool>> predicate = x => x.Name == "name test";
            var usersContext = context.Users.Where(predicate).ToList();

            // Act
            var users = await repository.GetManyWithFilterAsync(predicate);

            // Assert
            Assert.Equal(usersContext, users);

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

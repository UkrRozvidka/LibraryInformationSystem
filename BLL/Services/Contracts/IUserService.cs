using LibraryInformationSystem.BLL.DTOs.User;
using LibraryInformationSystem.LibraryInformationSystem.BLL.DTOs.User;

namespace BLL.Services.Contracts
{
    public interface IUserService
    {
        Task<long> Create(UserCreateDTO dto);
        Task Delete(long id);
        Task<IEnumerable<UserGetDTO>> GetAllAsync();
        Task<UserGetDTO> GetByIdAsync(long id);
        Task<UserWithBorrowBooksDTO> GetByIdWithBorrowsAsync(long id);
        Task<UserGetDTO> GetByNameAsync(string name);
    }
}
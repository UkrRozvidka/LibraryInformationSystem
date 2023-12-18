using LibraryInformationSystem.BLL.DTOs.User;
using LibraryInformationSystem.LibraryInformationSystem.BLL.DTOs.User;

namespace LibraryInformationSystem.BLL.Services.Contracts
{
    public interface IUserService
    {
        Task<long> Create(UserCreateDTO dto);
        Task Delete(long id);
        Task<IEnumerable<UserGetDTO>> GetAll();
        Task<UserGetDTO> GetById(long id);
        Task<UserWithBorrowBooksDTO> GetByIdWithBorrows(long id);
        Task<UserGetDTO> GetByName(string name);
    }
}
using LibraryInformationSystem.BLL.DTOs.Borrow;
using LibraryInformationSystem.LibraryInformationSystem.BLL.DTOs.User;

namespace LibraryInformationSystem.BLL.Services.Contracts
{
    public interface IBorrowService
    {
        Task<long> Create(BorrowCreateDTO dto);
        Task<IEnumerable<BorrowGetDTO>> GetAll();
        Task<BorrowGetDTO> GetById(long id);
        Task Update(long id, BorrowUpdateDto dto);
    }
}
using LibraryInformationSystem.BLL.DTOs.Borrow;
using LibraryInformationSystem.LibraryInformationSystem.BLL.DTOs.User;

namespace BLL.Services.Contracts
{
    public interface IBorrowService
    {
        Task<long> CreateAsync(BorrowCreateDTO dto);
        Task<IEnumerable<BorrowGetDTO>> GetAllAsync();
        Task<BorrowGetDTO> GetByIdAsync(long id);
        Task UpdateaAsync(long id, BorrowUpdateDto dto);
    }
}
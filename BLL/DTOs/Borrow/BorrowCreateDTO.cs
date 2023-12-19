using DAL.Entities;

namespace LibraryInformationSystem.BLL.DTOs.Borrow
{
    public class BorrowCreateDTO
    {
        public long UserId { get; set; }
        public long BookId { get; set; }
    }
}

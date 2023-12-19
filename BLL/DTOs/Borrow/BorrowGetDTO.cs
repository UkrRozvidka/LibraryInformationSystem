using DAL.Entities;

namespace LibraryInformationSystem.BLL.DTOs.Borrow
{
    public class BorrowGetDTO
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public long BookId { get; set; }
        public string BookName { get; set; } = string.Empty;
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public long StatusId { get; set; }
    }
}

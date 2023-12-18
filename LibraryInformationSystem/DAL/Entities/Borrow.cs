namespace LibraryInformationSystem.LibraryInformationSystem.DAL.Entities
{
    public class Borrow : BaseEntity
    {
        public long UserId { get; set; }
        public User User { get; set; }
        public long BookId { get; set; }
        public Book Book { get; set; }
        public DateTime BorrowDate { get; set; } = DateTime.Now;
        public DateTime ReturnDate { get; set; }
        public long StatusId { get; set; }
        public Status Status { get; set; }
    }
}

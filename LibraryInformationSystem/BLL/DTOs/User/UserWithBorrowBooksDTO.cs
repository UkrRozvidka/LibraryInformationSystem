using LibraryInformationSystem.BLL.DTOs.Book;
using LibraryInformationSystem.LibraryInformationSystem.BLL.DTOs.Book;

namespace LibraryInformationSystem.BLL.DTOs.User
{
    public class UserWithBorrowBooksDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public List<BookForBorrowListDTO> Borrows { get; set; } = new List<BookForBorrowListDTO>();
    }
}

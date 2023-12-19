using LibraryInformationSystem.BLL.DTOs.Book;
using LibraryInformationSystem.LibraryInformationSystem.BLL.DTOs.Book;

namespace LibraryInformationSystem.BLL.DTOs.User
{
    public class UserWithBorrowBooksDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public List<BookForBorrowListDTO> Borrows { get; set; } = new List<BookForBorrowListDTO>();
    }
}

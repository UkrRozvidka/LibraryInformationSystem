using DAL.Entities;

namespace LibraryInformationSystem.LibraryInformationSystem.BLL.DTOs.Book
{
    public class BookCreateDTO
    {
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string GenreName { get; set; } = string.Empty;
        public int PublishedYear { get; set; } 
        public int Count { get; set; }
    }
}

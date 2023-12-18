using LibraryInformationSystem.LibraryInformationSystem.DAL.Entities;

namespace LibraryInformationSystem.LibraryInformationSystem.BLL.DTOs.Book
{
    public class BookCreateDTO
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string GenreName { get; set; }
        public int PublishedYear { get; set; }
        public int Count { get; set; }
    }
}

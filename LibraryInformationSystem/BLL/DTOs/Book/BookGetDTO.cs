using LibraryInformationSystem.LibraryInformationSystem.DAL.Entities;

namespace LibraryInformationSystem.LibraryInformationSystem.BLL.DTOs.Book
{
    public class BookGetDTO
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public long GenreId { get; set; }
        public string GenreName { get; set; } = string.Empty;
        public int PublishedYear { get; set; }
        public int Count { get; set; }
        public int AvailableCount { get; set; }
    }
}

namespace LibraryInformationSystem.BLL.DTOs.Book
{
    public class BookForBorrowListDTO
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public long GenreId { get; set; }
        public string GenreName { get; set; }
        public int PublishedYear { get; set; }
    }
}

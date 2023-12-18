namespace LibraryInformationSystem.LibraryInformationSystem.DAL.Entities
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public long GenreId { get; set; }
        public Genre Genre { get; set; }
        public int PublishedYear { get; set; }
        public int Count {  get; set; }
        public ICollection<Borrow> Borrows { get; set;}
        
    }
}

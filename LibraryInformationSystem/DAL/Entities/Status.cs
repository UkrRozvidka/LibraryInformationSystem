namespace LibraryInformationSystem.LibraryInformationSystem.DAL.Entities
{
    public class Status : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Borrow> Borrows { get; set; } 
    }
}

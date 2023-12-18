namespace LibraryInformationSystem.LibraryInformationSystem.DAL.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<Borrow> Borrows { get; set; } 
    }
}

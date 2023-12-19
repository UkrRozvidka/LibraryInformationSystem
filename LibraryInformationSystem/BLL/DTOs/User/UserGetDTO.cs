namespace LibraryInformationSystem.LibraryInformationSystem.BLL.DTOs.User
{
    public class UserGetDTO
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
    }
}

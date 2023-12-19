using DAL.Entities;

namespace LibraryInformationSystem.LibraryInformationSystem.BLL.DTOs.User
{
    public class UserCreateDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
    }
}

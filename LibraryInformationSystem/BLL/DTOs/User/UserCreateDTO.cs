using LibraryInformationSystem.LibraryInformationSystem.DAL.Entities;

namespace LibraryInformationSystem.LibraryInformationSystem.BLL.DTOs.User
{
    public class UserCreateDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}

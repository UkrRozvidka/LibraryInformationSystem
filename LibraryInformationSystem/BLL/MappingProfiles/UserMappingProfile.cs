using AutoMapper;
using LibraryInformationSystem.BLL.DTOs.User;
using LibraryInformationSystem.LibraryInformationSystem.BLL.DTOs.User;
using LibraryInformationSystem.LibraryInformationSystem.DAL.Entities;

namespace LibraryInformationSystem.LibraryInformationSystem.BLL.MappingProfiles
{
    public class UserMappingProfile : Profile
    {
       public UserMappingProfile() 
       {
            CreateMap<UserCreateDTO, User>();
            CreateMap<User, UserGetDTO>();
            CreateMap<User, UserWithBorrowBooksDTO>();
        }
    }
}

using AutoMapper;
using DAL.Entities;
using LibraryInformationSystem.BLL.DTOs.User;
using LibraryInformationSystem.LibraryInformationSystem.BLL.DTOs.User;

namespace BLL.MappingProfiles
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

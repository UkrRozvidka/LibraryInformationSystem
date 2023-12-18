using AutoMapper;
using LibraryInformationSystem.BLL.DTOs.Borrow;
using LibraryInformationSystem.LibraryInformationSystem.BLL.DTOs.User;
using LibraryInformationSystem.LibraryInformationSystem.DAL.Entities;

namespace LibraryInformationSystem.BLL.MappingProfiles
{
    public class BorrowMappingProfile : Profile
    {
        public BorrowMappingProfile()
        {
            CreateMap<BorrowCreateDTO, Borrow>();
            CreateMap<Borrow, BorrowGetDTO>();
        }
    }
}

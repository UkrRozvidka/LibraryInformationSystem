using AutoMapper;
using DAL.Entities;
using LibraryInformationSystem.BLL.DTOs.Borrow;
using LibraryInformationSystem.LibraryInformationSystem.BLL.DTOs.User;

namespace BLL.MappingProfiles
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

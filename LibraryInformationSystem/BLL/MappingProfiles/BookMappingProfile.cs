using AutoMapper;
using LibraryInformationSystem.BLL.DTOs.Book;
using LibraryInformationSystem.LibraryInformationSystem.BLL.DTOs.Book;
using LibraryInformationSystem.LibraryInformationSystem.DAL.Entities;

namespace LibraryInformationSystem.LibraryInformationSystem.BLL.MappingProfiles
{
    public class BookMappingProfile : Profile
    {
        public BookMappingProfile() 
        {
            CreateMap<BookCreateDTO, Book>();
            CreateMap<Book, BookGetDTO>();
            CreateMap<Book, BookForBorrowListDTO>();
        }
    }
}

using AutoMapper;
using DAL.Entities;
using LibraryInformationSystem.BLL.DTOs.Book;
using LibraryInformationSystem.LibraryInformationSystem.BLL.DTOs.Book;

namespace BLL.MappingProfiles
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

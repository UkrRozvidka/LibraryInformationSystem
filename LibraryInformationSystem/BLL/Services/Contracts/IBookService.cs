using LibraryInformationSystem.BLL.DTOs.Book;
using LibraryInformationSystem.LibraryInformationSystem.BLL.DTOs.Book;

namespace LibraryInformationSystem.BLL.Services.Contracts
{
    public interface IBookService
    {
        Task<long> Create(BookCreateDTO dto);
        Task<IEnumerable<BookGetDTO>> GetAll();
        Task<IEnumerable<BookGetDTO>> GetAllWithFilter
            (IEnumerable<string> authors, IEnumerable<long> genres, int startYear = 0, int endYear = 0);
        Task<BookGetDTO> GetById(long id);
        Task<BookGetDTO> GetByTitle(string title);
        Task Update(long id, BookUpdateDTO dto);
        Task Delete(long id);

    }
}
using AutoMapper;
using LibraryInformationSystem.BLL.DTOs.Book;
using LibraryInformationSystem.BLL.Services.Contracts;
using LibraryInformationSystem.LibraryInformationSystem.BLL.DTOs.Book;
using LibraryInformationSystem.LibraryInformationSystem.DAL.Entities;
using LibraryInformationSystem.LibraryInformationSystem.DAL.Repository.Contracts;

namespace LibraryInformationSystem.LibraryInformationSystem.BLL.Services
{
    public class BookService : BaseService<Book>, IBookService
    {
        private readonly IGenericRepository<Borrow> _borrowRepository;
        private readonly IGenericRepository<Genre> _genreRepository;

        public BookService(IMapper mapper, IGenericRepository<Book> repository,
            IGenericRepository<Borrow> borrowRepository, IGenericRepository<Genre> genreRepository)
            : base(mapper, repository)
        {
            _borrowRepository = borrowRepository;
            _genreRepository = genreRepository;
        }

        public async Task<BookGetDTO> GetById(long id)
        {
            var book = await _repository.GetByIdAsync(id) ?? throw new Exception("Not found");
            var dto = _mapper.Map<BookGetDTO>(book);
            dto.AvailableCount = await AvailebleCount(book);
            dto.GenreName = await GetGenreNameAsync(book);
            return dto;
        }

        public async Task<BookGetDTO> GetByTitle(string title)
        {
            var book = await _repository.GetOneWithFilterAsync(b => b.Title == title) ?? throw new Exception("Not found");
            var dto = _mapper.Map<BookGetDTO>(book);
            dto.AvailableCount = await AvailebleCount(book);
            dto.GenreName = await GetGenreNameAsync(book);
            return dto;
        }

        public async Task<IEnumerable<BookGetDTO>> GetAll()
        {
            var books = await _repository.GetAllAsync();
            var dtos = new List<BookGetDTO>();

            foreach (var book in books)
            {
                var dto = _mapper.Map<BookGetDTO>(book);
                dto.AvailableCount = await AvailebleCount(book);
                dto.GenreName = await GetGenreNameAsync(book);
                dtos.Add(dto);
            }

            return dtos;
        }

        public async Task<long> Create(BookCreateDTO dto)
        {
            if (dto == null) throw new ArgumentNullException("DTO cannot be null.");
            var genre = await _genreRepository.GetOneWithFilterAsync(g => g.Name == dto.GenreName) ??
                throw new Exception("Incorect genre name.");
            var book = _mapper.Map<Book>(dto);
            book.Genre = genre;
            book.GenreId = genre.Id;
            var userId = await _repository.AddAsync(book);
            return userId;
        }

        public async Task<IEnumerable<BookGetDTO>> GetAllWithFilter(
            IEnumerable<string> authors, IEnumerable<long> genres, int startYear = 0, int endYear = 0)
        {
            var books = await _repository.GetManyWithFilterAsync(book =>
            (authors == null || authors.Any(author => author == book.Author)) &&
            (genres == null || genres.Any(genre => genre == book.GenreId)) &&
            (startYear == 0 || endYear == 0 || (book.PublishedYear >= startYear && book.PublishedYear <= endYear)));
            
            List<BookGetDTO> dtos = new List<BookGetDTO>();
            foreach (var book in books)
            {
                var dto = _mapper.Map<BookGetDTO>(book);
                dto.AvailableCount = await AvailebleCount(book);
                dtos.Add(dto);
            }
            return dtos;
        }

        public async Task Update(long id, BookUpdateDTO dto)
        {
            var book = await _repository.GetByIdAsync(id) ?? throw new Exception("Not found");
            book.Count = dto.Count;
            await _repository.UpdateAsync(book);
        }

        public async Task Delete(long id)
        {
            await _repository.DeleteAsync(id);
        }

        private async Task<int> AvailebleCount(Book book)
        {
            int count = book.Count;
            var borrows = await _borrowRepository.GetManyWithFilterAsync(br => br.BookId == book.Id);
            return count - borrows.Select(b => b.StatusId == 2).Count();
        }

        private async Task<string> GetGenreNameAsync(Book book)
        {
            var genre = await _genreRepository.GetByIdAsync(book.GenreId);
            return genre.Name;
        }

        public Task<IEnumerable<BookGetDTO>> GetAllWithFilter()
        {
            throw new NotImplementedException();
        }
    }
}

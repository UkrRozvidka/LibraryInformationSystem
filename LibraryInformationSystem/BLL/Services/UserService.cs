using LibraryInformationSystem.LibraryInformationSystem.DAL.Entities;
using AutoMapper;
using LibraryInformationSystem.LibraryInformationSystem.DAL.Repository.Contracts;
using LibraryInformationSystem.LibraryInformationSystem.BLL.DTOs.User;
using Microsoft.Identity.Client;
using LibraryInformationSystem.BLL.DTOs.User;
using LibraryInformationSystem.BLL.DTOs.Borrow;
using LibraryInformationSystem.LibraryInformationSystem.BLL.DTOs.Book;
using System.Collections.Generic;
using LibraryInformationSystem.BLL.Services.Contracts;
using LibraryInformationSystem.BLL.DTOs.Book;


namespace LibraryInformationSystem.LibraryInformationSystem.BLL.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        private protected IGenericRepository<Borrow> _borrowRepository;
        private protected IGenericRepository<Book> _bookRepository;
        private protected IGenericRepository<Genre> _genreRepository;

        public UserService(IMapper mapper, IGenericRepository<User> repository,
            IGenericRepository<Borrow> borrowRepository, IGenericRepository<Book> bookRepository,
            IGenericRepository<Genre> genreRepository)
            : base(mapper, repository)
        {
            _borrowRepository = borrowRepository;
            _bookRepository = bookRepository;
            _genreRepository = genreRepository;
        }

        public async Task<UserGetDTO> GetByIdAsync(long id)
        {
            var user = await _repository.GetByIdAsync(id) ?? throw new Exception("Not found");
            return _mapper.Map<UserGetDTO>(user);
        }

        public async Task<UserWithBorrowBooksDTO> GetByIdWithBorrowsAsync(long id)
        {
            var user = await _repository.GetByIdAsync(id) ?? throw new Exception("Not found");
            var dto = _mapper.Map<UserWithBorrowBooksDTO>(user);

            var borrows = await _borrowRepository.GetManyWithFilterAsync(br => br.UserId == id);
            foreach (var borrow in borrows)
            {
                var book = await _bookRepository.GetByIdAsync(borrow.BookId)
                    ?? throw new Exception("Not found");
                var genre = await _genreRepository.GetByIdAsync(book.GenreId);
                var dtoToAdd = _mapper.Map<BookForBorrowListDTO>(book);
                dtoToAdd.GenreName = genre.Name;
                dto.Borrows.Add(dtoToAdd);
            }
            return dto;
        }


        public async Task<UserGetDTO> GetByNameAsync(string name)
        {
            var user = await _repository.GetOneWithFilterAsync(u => u.Name == name) ?? throw new Exception("Not found");

            return _mapper.Map<UserGetDTO>(user);
        }

        public async Task<IEnumerable<UserGetDTO>> GetAllAsync()
        {
            var users = await _repository.GetAllAsync();

            return users.Select(u => _mapper.Map<UserGetDTO>(u));
        }

        public async Task<long> Create(UserCreateDTO dto)
        {
            if (dto == null) throw new ArgumentNullException("DTO cannot be null.");
            var user = _mapper.Map<User>(dto);
            var userId = await _repository.AddAsync(user);
            return userId;
        }

        public async Task Delete(long id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}

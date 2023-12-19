using AutoMapper;
using BLL.Services.Contracts;
using DAL.Entities;
using DAL.Repository.Contracts;
using LibraryInformationSystem.BLL.DTOs.Borrow;
using LibraryInformationSystem.LibraryInformationSystem.BLL.DTOs.User;

namespace BLL.Services
{
    public class BorrowService : BaseService<Borrow>, IBorrowService
    {
        private readonly IGenericRepository<User> _userRepository;
        private readonly IGenericRepository<Book> _bookRepository;
        private readonly IGenericRepository<Status> _statusRepository;


        public BorrowService(IMapper mapper, IGenericRepository<Borrow> repository,
            IGenericRepository<User> userRepository, IGenericRepository<Book> bookRepository,
            IGenericRepository<Status> statusRepository)
            : base(mapper, repository)
        {
            _userRepository = userRepository;
            _bookRepository = bookRepository;
            _statusRepository = statusRepository;
        }

        public async Task<long> CreateAsync(BorrowCreateDTO dto)
        {
            if (dto == null) throw new ArgumentNullException("DTO cannot be null");
            var borrow = _mapper.Map<Borrow>(dto);
            var user = await _userRepository.GetByIdAsync(dto.UserId) ?? throw new Exception("Incorect user id.");
            var book = await _bookRepository.GetByIdAsync(dto.BookId) ?? throw new Exception("Incorect book id.");
            var borrowsByUser = await _repository.GetManyWithFilterAsync(br => br.UserId == dto.UserId);
            if (borrowsByUser.Count() > 7) throw new Exception("Too many borrows already");

            borrow.UserId = user.Id;
            borrow.BookId = book.Id;
            borrow.BorrowDate = DateTime.Now;
            borrow.StatusId = 2;

            var borrowId = await _repository.AddAsync(borrow);
            return borrowId;
        }

        public async Task<BorrowGetDTO> GetByIdAsync(long id)
        {
            var borrow = await _repository.GetByIdAsync(id) ?? throw new Exception("Not found");
            return await FillPropertyAsync(_mapper.Map<BorrowGetDTO>(borrow));
        }

        public async Task<IEnumerable<BorrowGetDTO>> GetAllAsync()
        {
            var borrows = await _repository.GetAllAsync();
            List<BorrowGetDTO> result = new();
            foreach (var borrow in borrows)
            {
                result.Add(await FillPropertyAsync(_mapper.Map<BorrowGetDTO>(borrow)));
            }
            return result;
        }

        public async Task UpdateaAsync(long id, BorrowUpdateDto dto)
        {
            var borrow = await _repository.GetByIdAsync(id) ?? throw new Exception("Not found");
            var status = await _statusRepository.GetByIdAsync(dto.StatusId) ?? throw new Exception("Status id incorext");
            borrow.StatusId = status.Id;
            if (dto.StatusId == 1)
            {
                borrow.ReturnDate = DateTime.Now;
            }
            await _repository.UpdateAsync(borrow);
        }

        private async Task<BorrowGetDTO> FillPropertyAsync(BorrowGetDTO dto)
        {
            var user = await _userRepository.GetByIdAsync(dto.UserId) ?? throw new Exception("UserId incorect");
            var book = await _bookRepository.GetByIdAsync(dto.BookId) ?? throw new Exception("BookId incorect");
            dto.UserName = user.Name;
            dto.BookName = book.Title;
            return dto;
        }

    }
}

using LibraryInformationSystem.BLL.DTOs.Book;
using LibraryInformationSystem.BLL.DTOs.Borrow;
using LibraryInformationSystem.BLL.Services.Contracts;
using LibraryInformationSystem.LibraryInformationSystem.BLL.DTOs.Book;
using Microsoft.AspNetCore.Mvc;

namespace LibraryInformationSystem.API.Controllers
{
    [ApiController]
    [Route("api/book")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _service;

        public BookController(IBookService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookGetDTO>>> GetAllBooks()
        {
            try
            {
                var books = await _service.GetAll();
                return Ok(books);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("withFilter")]
        public async Task<ActionResult<IEnumerable<BookGetDTO>>> GetBooksWithFilter(
            [FromQuery] List<string> authors, [FromQuery] List<long> genresId, int startYear = 0, int endYear = 0)
        {
            try
            {
                var books = await _service.GetAllWithFilter(authors, genresId, startYear, endYear);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookGetDTO>> GetUserById(long id)
        {
            try
            {
                var book = await _service.GetById(id);
                return Ok(book);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddBook(BookCreateDTO dto)
        {
            try
            {
                await _service.Create(dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdeteBook(long id, BookUpdateDTO dto)
        {
            try
            {
                await _service.Update(id, dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBook(long id)
        {
            try
            {
                await _service.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

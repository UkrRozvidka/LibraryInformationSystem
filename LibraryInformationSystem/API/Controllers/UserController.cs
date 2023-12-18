using LibraryInformationSystem.BLL.Services.Contracts;
using LibraryInformationSystem.LibraryInformationSystem.BLL.DTOs.User;
using Microsoft.AspNetCore.Mvc;

namespace LibraryInformationSystem.LibraryInformationSystem.API.Controllers
{

    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service) 
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetUserById (long id, bool withBorrowBooks = false) 
        {
            try
            {
                if(!withBorrowBooks)
                {
                    var user = await _service.GetById(id);
                    return Ok(user);
                }
                var userWithBorrowBooks = await _service.GetByIdWithBorrows(id);
                return Ok(userWithBorrowBooks);
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("byName/{name}")]
        public async Task<ActionResult<UserGetDTO>> GetUserByName(string name)
        {
            try
            {
                var user = await _service.GetByName(name);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<UserGetDTO>> GetAllUsers()
        {
            try
            {
                var users = await _service.GetAll();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Adduser(UserCreateDTO dto)
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

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(long id)
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

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserViewBack.Application.Handlers.Interfaces;
using UserViewBack.Domain.Dto;

namespace UserViewBack.Web.Controllers
{
    [ApiController]
    public class UserController: ControllerBase
    {
        // Handlers necesarios para realizar operaciones de lectura y escritura
        private readonly IUserCommandHandler _userCommandHandler;
        private readonly IUserQueryHandler _userQueryHandler;

        // Constructor para inyectar dependencias
        public UserController(IUserCommandHandler userCommandHandler, IUserQueryHandler userQueryHandler)
        {
            _userCommandHandler = userCommandHandler;
            _userQueryHandler = userQueryHandler;
        }

        // GET: api/users
        [HttpGet("api/users")]
        public async Task<ActionResult<IEnumerable<UserReadDto>>> GetUsers()
        {
            var users = await _userQueryHandler.GetAllAsync();
            return Ok(users);
        }

        // GET: api/users/{id}
        [HttpGet("api/users/{id}")]
        public async Task<ActionResult<UserReadDto>> GetUser(int id)
        {
            var user = await _userQueryHandler.GetByIdAsync(id);
            if(user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // POST: api/users
        [HttpPost("api/users")]
        public async Task<ActionResult<UserReadDto>> CreateUser(UserCreateDto userCreateDto)
        {
            var user = await _userCommandHandler.CreateAsync(userCreateDto);
            // Devolvemos un action con el user actualizado
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        // PUT: api/users/{id}
        [HttpPut("api/users/{id}")]
        public async Task<IActionResult> UpdateUser(int id, UserUpdateDto userUpdateDto)
        {
            if(id != userUpdateDto.Id)
            {
                return BadRequest();
            }

            await _userCommandHandler.UpdateAsync(userUpdateDto);
            return NoContent();
        }

        // DELETE: api/users/{id}
        [HttpDelete("api/users/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userCommandHandler.DeleteAsync(id);
            return NoContent();
        }
    }
}

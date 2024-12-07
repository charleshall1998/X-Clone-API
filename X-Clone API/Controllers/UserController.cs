using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using X_Clone_API.Models.Data;
using X_Clone_API.Models.Dto;
using X_Clone_API.Services.Interfaces;

namespace X_Clone_API.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        private IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserDto>> CreateUser([FromBody] CreateUserDto createUserDto)
        {
            if (createUserDto is null)
            {
                return BadRequest("User object is null");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest("User object is invalid");
            }

            var user = _mapper.Map<User>(createUserDto);

            var userDto = await _userService.CreateUser(user);

            return CreatedAtRoute("GetUserById", new { id = userDto.Id }, userDto);
        }

        [HttpGet("id/{userId}", Name = "GetUserById")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserDto>> GetUserById(int userId)
        {
            var user = await _userService.GetUserById(userId);

            if (user is null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet("email/{email}", Name = "GetUserByEmail")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserDto>> GetUserByEmail(string email)
        {
            var user = await _userService.GetUserByEmail(email);

            if (user is null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet("username/{username}", Name = "GetUserByUsername")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserDto>> GetUserByUsername(string username)
        {
            var user = await _userService.GetUserByUsername(username);

            if (user is null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet("users", Name = "GetAllUsers")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UserDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();

            if (users is null)
            {
                return NotFound();
            }

            return Ok(users);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserDto>> UpdateUser([FromBody] UserDto user)
        {
            var updatedUser = await _userService.UpdateUser(user);

            if (updatedUser is null)
            {
                return NotFound();
            }

            return Ok(updatedUser);
        }

        [HttpDelete("{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<ActionResult<bool>> DeleteUser(int userId)
        {
            var isDeleted = await _userService.DeleteUser(userId);

            return Ok(isDeleted);
        }
    }
}

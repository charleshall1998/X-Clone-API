using Microsoft.AspNetCore.Mvc;
using X_Clone_API.Data;
using X_Clone_API.Services.Interfaces;

namespace X_Clone_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private IUserService _userService;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<User> CreateUser(string username, string email)
        {
            var newUser = await _userService.CreateUser(username, email);

            return newUser;
        }

        [HttpGet("id/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<User> GetUserById(int userId)
        {
            var user = await _userService.GetUserById(userId);

            return user;
        }

        [HttpGet("email/{email}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<User> GetUserByEmail(string email)
        {
            var user = await _userService.GetUserByEmail(email);

            return user;
        }

        [HttpGet("username/{username}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<User> GetUserByUsername(string username)
        {
            var user = await _userService.GetUserByUsername(username);

            return user;
        }

        [HttpGet("users")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();

            return users;
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<User> UpdateUser(User user)
        {
            var updatedUser = await _userService.UpdateUser(user);

            return updatedUser;
        }

        [HttpDelete("{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<bool> DeleteUser(int userId)
        {
            var isDeleted = await _userService.DeleteUser(userId);

            return isDeleted;
        }
    }
}

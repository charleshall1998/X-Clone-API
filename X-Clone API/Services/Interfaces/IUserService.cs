using X_Clone_API.Models.Data;
using X_Clone_API.Models.Dto;

namespace X_Clone_API.Services.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// Creates a new user record.
        /// </summary>
        /// <param name="user">The user to be created</param>
        /// <returns>The new user record.</returns>
        public Task<UserDto> CreateUser(User user);

        /// <summary>
        /// Retrieves a user via their id.
        /// </summary>
        /// <param name="id">The id of the user being searched for.</param>
        /// <returns>The found user, or null if not found.</returns>
        public Task<UserDto> GetUserById(int id);

        /// <summary>
        /// Retrieves a user via their email.
        /// </summary>
        /// <param name="email">The email of the user being searched for.</param>
        /// <returns>The found user, or null if not found.</returns>
        public Task<UserDto> GetUserByEmail(string email);

        /// <summary>
        /// Retrieves a user via their username.
        /// </summary>
        /// <param name="email">The username of the user being searched for.</param>
        /// <returns>The found user, or null if not found.</returns>
        public Task<UserDto> GetUserByUsername(string username);

        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <returns>Returns all users</returns>
        public Task<IEnumerable<UserDto>> GetAllUsers();

        /// <summary>
        /// Updates a given user
        /// </summary>
        /// <param name="user">The user to be updated</param>
        /// <returns>The newly updated user.</returns>
        public Task<UserDto> UpdateUser(UserDto user);

        /// <summary>
        /// Deletes an existing user record.
        /// </summary>
        /// <param name="id">The id of the user being deleted.</param>
        /// <returns>True if the operation was successful, false if not.</returns>
        public Task<bool> DeleteUser(int id);
    }
}

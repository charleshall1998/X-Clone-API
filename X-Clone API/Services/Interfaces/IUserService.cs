using X_Clone_API.Data;

namespace X_Clone_API.Services.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// Creates a new user record.
        /// </summary>
        /// <param name="username">The username to be assigned to the created user.</param>
        /// <param name="email">The email to be assigned to the created user.</param>
        /// <returns>The new user record.</returns>
        public Task<User> CreateUser(string username, string email);

        /// <summary>
        /// Retrieves a user via their id.
        /// </summary>
        /// <param name="id">The id of the user being searched for.</param>
        /// <returns>The found user, or null if not found.</returns>
        public Task<User> GetUserById(int id);

        /// <summary>
        /// Retrieves a user via their email.
        /// </summary>
        /// <param name="email">The email of the user being searched for.</param>
        /// <returns>The found user, or null if not found.</returns>
        public Task<User> GetUserByEmail(string email);

        /// <summary>
        /// Retrieves a user via their username.
        /// </summary>
        /// <param name="email">The username of the user being searched for.</param>
        /// <returns>The found user, or null if not found.</returns>
        public Task<User> GetUserByUsername(string username);

        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <returns>Returns all users</returns>
        public Task<IEnumerable<User>> GetAllUsers();

        /// <summary>
        /// Deletes an existing user record.
        /// </summary>
        /// <param name="id">The id of the user being deleted.</param>
        /// <returns>True if the operation was successful, false if not.</returns>
        public bool DeleteUserById(int id);
    }
}

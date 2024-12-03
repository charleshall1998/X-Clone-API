using X_Clone_API.Models.Data;
using X_Clone_API.Models.Dto;

namespace X_Clone_API.Data.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public Task<User> CreateUser(string username, string email);

        public Task<User> GetUserById(int id);

        public Task<User> GetUserByEmail(string email);

        public Task<User> GetUserByUsername(string username);

        public Task<IEnumerable<User>> GetAllUsers();

        public Task<User> UpdateUser(UserDto user);

        public Task<bool> DeleteUser(int id);
    }
}

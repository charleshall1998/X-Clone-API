using X_Clone_API.Models.Dto;

namespace X_Clone_API.Repository.Interfaces
{
    public interface IUserRepository
    {
        public Task<UserDto> CreateUser(string username, string email);

        public Task<UserDto> GetUserById(int id);

        public Task<UserDto> GetUserByEmail(string email);

        public Task<UserDto> GetUserByUsername(string username);

        public Task<IEnumerable<UserDto>> GetAllUsers();

        public Task<UserDto> UpdateUser(UserDto user);

        public Task<bool> DeleteUser(int id);
    }
}

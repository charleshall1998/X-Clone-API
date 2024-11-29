using X_Clone_API.Models.Dto;
using X_Clone_API.Repository.Interfaces;
using X_Clone_API.Services.Interfaces;

namespace X_Clone_API.Services.Implementations
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto> CreateUser(string username, string email)
        {
            //TODO: Validations

            return await _userRepository.CreateUser(username, email);
        }

        public async Task<UserDto> GetUserById(int id)
        {
            return await _userRepository.GetUserById(id);
        }

        public async Task<UserDto> GetUserByEmail(string email)
        {
            return await _userRepository.GetUserByEmail(email);
        }

        public async Task<UserDto> GetUserByUsername(string username)
        {
            return await _userRepository.GetUserByUsername(username);
        }

        public async Task<IEnumerable<UserDto>> GetAllUsers()
        {
            return await _userRepository.GetAllUsers();
        }

        public async Task<UserDto> UpdateUser(UserDto user)
        {
            return await _userRepository.UpdateUser(user);
        }

        public async Task<bool> DeleteUser(int userId)
        {
            return await _userRepository.DeleteUser(userId);
        }
    }
}

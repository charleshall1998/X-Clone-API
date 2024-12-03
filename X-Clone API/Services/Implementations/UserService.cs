using AutoMapper;
using X_Clone_API.Data.Repositories.Interfaces;
using X_Clone_API.Models.Dto;
using X_Clone_API.Services.Interfaces;

namespace X_Clone_API.Services.Implementations
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private IMapper _mapper;
        private ILogger _logger;

        public UserService(IUserRepository userRepository, IMapper mapper, ILogger logger)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<UserDto> CreateUser(string username, string email)
        {
            _logger.LogInformation("Creating user with username: {username}, email: {email}", username, email);

            //TODO: Validations

            var user = await _userRepository.CreateUser(username, email);

            var userDto = _mapper.Map<UserDto>(user);

            _logger.LogInformation("Successfully created user with ID: {userId} posts", userDto.Id);

            return userDto;
        }

        public async Task<UserDto> GetUserById(int id)
        {
            var user = await _userRepository.GetUserById(id);

            var userDto = _mapper.Map<UserDto>(user);

            return userDto;
        }

        public async Task<UserDto> GetUserByEmail(string email)
        {
            var user = await _userRepository.GetUserByEmail(email);

            var userDto = _mapper.Map<UserDto>(user);

            return userDto;
        }

        public async Task<UserDto> GetUserByUsername(string username)
        {
            var user = await _userRepository.GetUserByUsername(username);

            var userDto = _mapper.Map<UserDto>(user);

            return userDto;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsers();

            var userDtos = _mapper.Map<IEnumerable<UserDto>>(users);

            return userDtos;
        }

        public async Task<UserDto> UpdateUser(UserDto user)
        {
            var updatedUser = await _userRepository.UpdateUser(user);

            var userDto = _mapper.Map<UserDto>(updatedUser);

            return userDto;
        }

        public async Task<bool> DeleteUser(int userId)
        {
            return await _userRepository.DeleteUser(userId);
        }
    }
}

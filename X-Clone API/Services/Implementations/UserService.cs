using Microsoft.EntityFrameworkCore;
using X_Clone_API.Data;
using X_Clone_API.Models.Dto;
using X_Clone_API.Services.Interfaces;

namespace X_Clone_API.Services.Implementations
{
    public class UserService : IUserService
    {
        private AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UserDto> CreateUser(string username, string email)
        {
            var user = new User
            {
                Username = username,
                Email = email,
                CreatedAt = DateTime.Now,
            };

            await _context.AddAsync(user);

            await _context.SaveChangesAsync();

            var userDto = new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                CreatedAt = user.CreatedAt,
            };

            return userDto;
        }

        public async Task<UserDto> GetUserById(int id)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Id == id);

            if (user is null)
            {
                return null;
            }

            var userDto = new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                CreatedAt = user.CreatedAt
            };

            return userDto;
        }

        public async Task<UserDto> GetUserByEmail(string email)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Email == email);

            if (user is null)
            {
                return null;
            }

            var userDto = new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                CreatedAt = user.CreatedAt
            };

            return userDto;
        }

        public async Task<UserDto> GetUserByUsername(string username)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Username == username);

            if (user is null)
            {
                return null;
            }

            var userDto = new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                CreatedAt = user.CreatedAt
            };

            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserDto>> GetAllUsers()
        {
            var users = await _context.Users.ToListAsync();


            var userDtos = new List<UserDto>();

            foreach (var user in users)
            {
                var userDto = new UserDto
                {
                    Id = user.Id,
                    Username = user.Username,
                    Email = user.Email,
                    CreatedAt = user.CreatedAt
                };

                userDtos.Add(userDto);
            }

            return userDtos;
        }

        public async Task<UserDto> UpdateUser(UserDto user)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}

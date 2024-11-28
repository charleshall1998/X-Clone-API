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
            try
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
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                throw new Exception();
            }
        }

        public async Task<UserDto> GetUserById(int id)
        {
            try
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
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                throw new Exception();
            }
        }

        public async Task<UserDto> GetUserByEmail(string email)
        {
            try
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
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                throw new Exception();
            }
        }

        public async Task<UserDto> GetUserByUsername(string username)
        {
            try
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

                return userDto;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                throw new Exception();
            }
        }

        public async Task<IEnumerable<UserDto>> GetAllUsers()
        {
            try
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
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                throw new Exception();
            }
        }

        public async Task<UserDto> UpdateUser(UserDto user)
        {
            try
            {
                var userToUpdate = await _context.Users.FindAsync(user.Id);

                // TODO: Custom exception handling
                if (userToUpdate is null)
                {
                    return null;
                }

                userToUpdate.Username = user.Username;
                userToUpdate.Email = user.Email;

                await _context.SaveChangesAsync();

                var userToReturn = new UserDto
                {
                    Id = userToUpdate.Id,
                    Username = userToUpdate.Username,
                    Email = userToUpdate.Email,
                    CreatedAt = userToUpdate.CreatedAt,
                };

                return userToReturn;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                throw new Exception();
            }
        }

        public async Task<bool> DeleteUser(int userId)
        {
            try
            {
                var userToDelete = await _context.Users.FindAsync(userId);

                if (userToDelete is null)
                {
                    return false;
                }

                _context.Remove(userToDelete);

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                throw new Exception();
            }
        }
    }
}

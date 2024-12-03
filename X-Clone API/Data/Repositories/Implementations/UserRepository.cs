using Microsoft.EntityFrameworkCore;
using X_Clone_API.Data;
using X_Clone_API.Data.Repositories.Interfaces;
using X_Clone_API.Models.Data;
using X_Clone_API.Models.Dto;

namespace X_Clone_API.Data.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> CreateUser(string username, string email)
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

                return user;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                throw new Exception();
            }
        }

        //TODO: Implement paging
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            try
            {
                var users = await _context.Users.ToListAsync();

                return users;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                throw new Exception();
            }
        }

        public async Task<User> GetUserByEmail(string email)
        {
            try
            {
                var user = await _context.Users.SingleOrDefaultAsync(x => x.Email == email);

                if (user is null)
                {
                    return null;
                }

                return user;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                throw new Exception();
            }
        }

        public async Task<User> GetUserById(int id)
        {
            try
            {
                var user = await _context.Users.SingleOrDefaultAsync(x => x.Id == id);

                if (user is null)
                {
                    return null;
                }

                return user;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                throw new Exception();
            }
        }

        public async Task<User> GetUserByUsername(string username)
        {
            try
            {
                var user = await _context.Users.SingleOrDefaultAsync(x => x.Username == username);

                if (user is null)
                {
                    return null;
                }

                return user;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                throw new Exception();
            }
        }

        public async Task<User> UpdateUser(UserDto user)
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

                return userToUpdate;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                throw new Exception();
            }
        }

        public async Task<bool> DeleteUser(int id)
        {
            try
            {
                var userToDelete = await _context.Users.FindAsync(id);

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

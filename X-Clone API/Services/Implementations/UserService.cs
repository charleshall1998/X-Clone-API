using Microsoft.EntityFrameworkCore;
using X_Clone_API.Data;
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

        public async Task<User> CreateUser(string username, string email)
        {
            //var user = new User
            //{
            //    Username = username,
            //    Email = email,
            //    CreatedAt = DateTime.Now,
            //};

            //var createdUser = await _context.AddAsync(user);

            //await _context.SaveChangesAsync();

            //return createdUser;

            throw new NotImplementedException();
        }

        public async Task<User> GetUserById(int id)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Id == id);

            return user;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Email == email);

            return user;
        }

        public async Task<User> GetUserByUsername(string username)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Username == username);

            return user;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var users = await _context.Users.ToListAsync();

            return users;
        }

        public bool DeleteUserById(int id)
        {
            throw new NotImplementedException();
        }
    }
}

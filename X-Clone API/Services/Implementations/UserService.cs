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

        public User CreateUser(string username, string email)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserById(int id)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Id == id);

            return user;
        }

        public User GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public User GetUserByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUserById(int id)
        {
            throw new NotImplementedException();
        }
    }
}

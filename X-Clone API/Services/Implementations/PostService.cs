using Microsoft.EntityFrameworkCore;
using X_Clone_API.Data;
using X_Clone_API.Services.Interfaces;

namespace X_Clone_API.Services.Implementations
{
    public class PostService : IPostService
    {
        private AppDbContext _context;

        public PostService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Post> CreatePost(int userId, string content)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Post>> GetPostsByUser(int userId)
        {
            var posts = await _context.Posts.Where(post => post.UserId == userId).ToListAsync();

            return posts;
        }

        public async Task<IEnumerable<Post>> GetPosts()
        {
            var posts = await _context.Posts.ToListAsync();

            return posts;
        }

        public async Task<int> UpdatePostLikeCount(int postId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeletePost(int postId)
        {
            throw new NotImplementedException();
        }
    }
}

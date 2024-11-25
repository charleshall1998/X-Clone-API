using Microsoft.EntityFrameworkCore;
using X_Clone_API.Data;
using X_Clone_API.Models.Dto;
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

        public async Task<PostDto> CreatePost(int userId, string content)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PostDto>> GetPostsByUser(int userId)
        {
            var posts = await _context.Posts.Where(post => post.UserId == userId).ToListAsync();

            if (!posts.Any())
            {
                return null;
            }

            var postDtos = new List<PostDto>();

            foreach (var post in posts)
            {
                var postDto = new PostDto
                {
                    Id = post.Id,
                    Content = post.Content,
                    CreatedAt = post.CreatedAt,
                    LikeCount = post.LikeCount
                };

                postDtos.Add(postDto);
            }

            return postDtos;
        }

        public async Task<IEnumerable<PostDto>> GetPosts()
        {
            var posts = await _context.Posts.ToListAsync();

            if (!posts.Any())
            {
                return null;
            }

            var postDtos = new List<PostDto>();

            foreach (var post in posts)
            {
                var postDto = new PostDto
                {
                    Id = post.Id,
                    Content = post.Content,
                    CreatedAt = post.CreatedAt,
                    LikeCount = post.LikeCount
                };

                postDtos.Add(postDto);
            }

            return postDtos;
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

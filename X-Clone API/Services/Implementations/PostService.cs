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
            var post = new Post
            {
                Content = content,
                CreatedAt = DateTime.Now,
                UserId = userId
            };

            await _context.AddAsync(post);

            await _context.SaveChangesAsync();

            var postDto = new PostDto
            {
                Id = post.Id,
                Content = post.Content,
                CreatedAt = post.CreatedAt,
                LikeCount = post.LikeCount
            };

            return postDto;
        }

        public async Task<IEnumerable<PostDto>> GetPostsByUser(int userId)
        {
            var posts = await _context.Posts.Where(post => post.UserId == userId).ToListAsync();

            //TODO: Custom exception handling
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

            //TODO: Custom exception handling
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

        //TODO: Refactor to consider concurrency issues
        public async Task<int> UpdatePostLikeCount(int postId)
        {
            var postToUpdate = await _context.Posts.FindAsync(postId);

            //TODO: Custom exception handling
            if (postToUpdate is null)
            {
                return -1;
            }

            postToUpdate.LikeCount += 1;

            await _context.SaveChangesAsync();

            return postToUpdate.LikeCount;
        }

        public async Task<bool> DeletePost(int postId)
        {
            var postToDelete = await _context.Posts.FindAsync(postId);

            if (postToDelete is null)
            {
                return false;
            }

            _context.Remove(postToDelete);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}

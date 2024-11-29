using Microsoft.EntityFrameworkCore;
using X_Clone_API.Data;
using X_Clone_API.Models.Dto;
using X_Clone_API.Repository.Interfaces;

namespace X_Clone_API.Repository.Implementations
{
    public class PostRepository : IPostRepository
    {
        private readonly AppDbContext _context;

        public PostRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<PostDto> CreatePost(int userId, string content)
        {
            try
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
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                throw new Exception();
            }
        }

        //TODO: Implement paging
        public async Task<IEnumerable<PostDto>> GetAllPosts()
        {
            try
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
            catch (Exception ex)
            {
                Console.Error?.WriteLine(ex);
                throw new Exception();
            }
        }

        public async Task<IEnumerable<PostDto>> GetPostsByUser(int userId)
        {
            try
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
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                throw new Exception();
            }
        }

        //TODO: Refactor to consider concurrency issues
        public async Task<int> UpdatePostLikeCount(int postId)
        {
            try
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
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                throw new Exception();
            }
        }

        public async Task<bool> DeletePost(int postId)
        {
            try
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
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                throw new Exception();
            }
        }
    }
}

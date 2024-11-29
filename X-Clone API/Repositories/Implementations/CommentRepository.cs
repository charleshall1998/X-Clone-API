using Microsoft.EntityFrameworkCore;
using X_Clone_API.Data;
using X_Clone_API.Models.Dto;
using X_Clone_API.Repository.Interfaces;

namespace X_Clone_API.Repository.Implementations
{
    public class CommentRepository : ICommentRepository
    {
        private readonly AppDbContext _context;

        public CommentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CommentDto> CreateComment(int postId, int userId, string content)
        {
            try
            {
                var comment = new Comment
                {
                    Content = content,
                    CreatedAt = DateTime.Now,
                    UserId = userId,
                    PostId = postId
                };
                await _context.AddAsync(comment);

                await _context.SaveChangesAsync();

                var commentDto = new CommentDto
                {
                    Id = comment.Id,
                    Content = comment.Content,
                    CreatedAt = comment.CreatedAt,
                    UserId = comment.UserId,
                    PostId = comment.PostId
                };

                return commentDto;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                throw new Exception();
            }
        }

        public async Task<IEnumerable<CommentDto>> GetCommentsByPost(int postId)
        {
            try
            {
                var comments = await _context.Comments.Where(c => c.PostId == postId).ToListAsync();

                //TODO: Custom exception handling
                if (!comments.Any())
                {
                    return null;
                }

                var commentDtos = new List<CommentDto>();

                foreach (var comment in comments)
                {
                    var commentDto = new CommentDto
                    {
                        Id = comment.Id,
                        Content = comment.Content,
                        CreatedAt = comment.CreatedAt,
                        UserId = comment.UserId,
                        PostId = comment.PostId
                    };
                }

                return commentDtos;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                throw new Exception();
            }
        }

        public async Task<CommentDto> UpdateComment(int commentId, string content)
        {
            try
            {
                var commentToUpdate = await _context.Comments.FindAsync(commentId);

                //TODO: Custom exception handling
                if (commentToUpdate is null)
                {
                    return null;
                }

                commentToUpdate.Content = content;

                await _context.SaveChangesAsync();

                var commentToReturn = new CommentDto
                {
                    Id = commentToUpdate.Id,
                    Content = commentToUpdate.Content,
                    CreatedAt = commentToUpdate.CreatedAt,
                    UserId = commentToUpdate.UserId,
                    PostId = commentToUpdate.PostId
                };

                return commentToReturn;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                throw new Exception();
            }
        }

        public async Task<bool> DeleteComment(int commentId)
        {
            try
            {
                var commentToDelete = await _context.Comments.FindAsync(commentId);

                if (commentToDelete is null)
                {
                    return false;
                }

                _context.Remove(commentToDelete);

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

using Microsoft.EntityFrameworkCore;
using X_Clone_API.Data.Repositories.Interfaces;
using X_Clone_API.Models.Data;

namespace X_Clone_API.Data.Repositories.Implementations
{
    public class CommentRepository : ICommentRepository
    {
        private readonly AppDbContext _context;

        public CommentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Comment> CreateComment(Comment comment)
        {
            try
            {
                await _context.AddAsync(comment);

                await _context.SaveChangesAsync();

                return comment;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                throw new Exception();
            }
        }

        public async Task<Comment> GetCommentById(int commentId)
        {
            try
            {
                var comment = await _context.Comments.FindAsync(commentId);

                //TODO: Custom exception handling
                if (comment is null)
                {
                    return null;
                }

                return comment;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                throw new Exception();
            }
        }

        public async Task<IEnumerable<Comment>> GetCommentsByPost(int postId)
        {
            try
            {
                var comments = await _context.Comments.Where(c => c.PostId == postId).ToListAsync();

                //TODO: Custom exception handling
                if (!comments.Any())
                {
                    return null;
                }

                return comments;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                throw new Exception();
            }
        }

        public async Task<Comment> UpdateComment(int commentId, string content)
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

                return commentToUpdate;
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

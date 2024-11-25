using Microsoft.EntityFrameworkCore;
using X_Clone_API.Data;
using X_Clone_API.Models.Dto;
using X_Clone_API.Services.Interfaces;

namespace X_Clone_API.Services.Implementations
{
    public class CommentService : ICommentService
    {
        private AppDbContext _context;

        public CommentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CommentDto> CreateComment(int postId, int userId, string content)
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

        public async Task<IEnumerable<CommentDto>> GetCommentsByPost(int postId)
        {
            var comments = await _context.Comments.Where(c => c.PostId == postId).ToListAsync();

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

        public async Task<CommentDto> UpdateComment(Comment comment)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteComment(int postId)
        {
            throw new NotImplementedException();
        }

    }
}

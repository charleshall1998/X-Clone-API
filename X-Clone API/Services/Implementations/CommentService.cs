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

        public async Task<CommentDto> CreateComment(int userId, string content)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CommentDto>> GetCommentsByPost(int postId)
        {
            throw new NotImplementedException();
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

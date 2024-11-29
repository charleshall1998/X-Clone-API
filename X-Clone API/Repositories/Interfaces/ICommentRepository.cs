using X_Clone_API.Models.Dto;

namespace X_Clone_API.Repository.Interfaces
{
    public interface ICommentRepository
    {
        public Task<CommentDto> CreateComment(int postId, int userId, string content);

        public Task<IEnumerable<CommentDto>> GetCommentsByPost(int postId);

        public Task<CommentDto> UpdateComment(int commentId, string content);

        public Task<bool> DeleteComment(int commentId);
    }
}

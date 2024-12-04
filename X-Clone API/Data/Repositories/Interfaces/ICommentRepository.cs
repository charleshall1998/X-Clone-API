using X_Clone_API.Models.Data;

namespace X_Clone_API.Data.Repositories.Interfaces
{
    public interface ICommentRepository
    {
        public Task<Comment> CreateComment(Comment comment);

        public Task<Comment> GetCommentById(int commentId);

        public Task<IEnumerable<Comment>> GetCommentsByPost(int postId);

        public Task<Comment> UpdateComment(int commentId, string content);

        public Task<bool> DeleteComment(int commentId);
    }
}

using X_Clone_API.Models.Dto;
using X_Clone_API.Repository.Interfaces;
using X_Clone_API.Services.Interfaces;

namespace X_Clone_API.Services.Implementations
{
    public class CommentService : ICommentService
    {
        private ICommentRepository _commentRepository;

        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<CommentDto> CreateComment(int postId, int userId, string content)
        {
            //TODO: Validations

            return await _commentRepository.CreateComment(postId, userId, content);
        }

        //TODO: Implement paging
        public async Task<IEnumerable<CommentDto>> GetCommentsByPost(int postId)
        {
            return await _commentRepository.GetCommentsByPost(postId);
        }

        public async Task<CommentDto> UpdateComment(int commentId, string content)
        {
            return await _commentRepository.UpdateComment(commentId, content);
        }

        public async Task<bool> DeleteComment(int commentId)
        {
            return await _commentRepository.DeleteComment(commentId);
        }

    }
}

using AutoMapper;
using X_Clone_API.Data.Repositories.Interfaces;
using X_Clone_API.Models.Dto;
using X_Clone_API.Services.Interfaces;

namespace X_Clone_API.Services.Implementations
{
    public class CommentService : ICommentService
    {
        private ICommentRepository _commentRepository;
        private IMapper _mapper;
        private ILogger _logger;

        public CommentService(ICommentRepository commentRepository, IMapper mapper, ILogger logger)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<CommentDto> CreateComment(int postId, int userId, string content)
        {
            _logger.LogInformation("Creating comment for post ID: {postId}, user ID {UserId}", postId, userId);

            //TODO: Validations

            var comment = await _commentRepository.CreateComment(postId, userId, content);

            var commentDto = _mapper.Map<CommentDto>(comment);

            _logger.LogInformation("Successfully created comment with comment ID {commentId}", commentDto.Id);

            return commentDto;
        }

        //TODO: Implement paging
        public async Task<IEnumerable<CommentDto>> GetCommentsByPost(int postId)
        {
            _logger.LogInformation("Retrieving comment for post ID: {postId}", postId);

            var comments = await _commentRepository.GetCommentsByPost(postId);

            var commentDtos = _mapper.Map<IEnumerable<CommentDto>>(comments);

            _logger.LogInformation("Successfully retrieved {count} comments", commentDtos.Count());

            return commentDtos;
        }

        public async Task<CommentDto> UpdateComment(int commentId, string content)
        {
            _logger.LogInformation("Updating comment with comment ID {commentId}", commentId);

            //TODO: Validations

            var comment = await _commentRepository.UpdateComment(commentId, content);

            var commentDto = _mapper.Map<CommentDto>(comment);

            _logger.LogInformation("Successfully updated comment with comment ID {commentId}", commentDto.Id);

            return commentDto;
        }

        public async Task<bool> DeleteComment(int commentId)
        {
            _logger.LogInformation("Deleting comment with comment ID {commentId}", commentId);

            var isDeleted = await _commentRepository.DeleteComment(commentId);

            _logger.LogInformation("Successfully deleted comment with comment ID {commentId}", commentId);

            return isDeleted;
        }

    }
}

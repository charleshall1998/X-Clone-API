using AutoMapper;
using X_Clone_API.Models.Dto;
using X_Clone_API.Repository.Interfaces;
using X_Clone_API.Services.Interfaces;

namespace X_Clone_API.Services.Implementations
{
    public class CommentService : ICommentService
    {
        private ICommentRepository _commentRepository;
        private IMapper _mapper;

        public CommentService(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<CommentDto> CreateComment(int postId, int userId, string content)
        {
            //TODO: Validations
            var comment = await _commentRepository.CreateComment(postId, userId, content);

            var commentDto = _mapper.Map<CommentDto>(comment);

            return commentDto;
        }

        //TODO: Implement paging
        public async Task<IEnumerable<CommentDto>> GetCommentsByPost(int postId)
        {
            var comments = await _commentRepository.GetCommentsByPost(postId);

            var commentDtos = _mapper.Map<IEnumerable<CommentDto>>(comments);

            return commentDtos;
        }

        public async Task<CommentDto> UpdateComment(int commentId, string content)
        {
            var comment = await _commentRepository.UpdateComment(commentId, content);

            var commentDto = _mapper.Map<CommentDto>(comment);

            return commentDto;
        }

        public async Task<bool> DeleteComment(int commentId)
        {
            return await _commentRepository.DeleteComment(commentId);
        }

    }
}

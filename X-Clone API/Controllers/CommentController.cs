using Microsoft.AspNetCore.Mvc;
using X_Clone_API.Data;
using X_Clone_API.Models.Dto;
using X_Clone_API.Services.Interfaces;

namespace X_Clone_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly ILogger<CommentController> _logger;
        private ICommentService _commentService;

        public CommentController(ILogger<CommentController> logger, ICommentService commentService)
        {
            _logger = logger;
            _commentService = commentService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<CommentDto> CreateComment(int postId, int userId, string content)
        {
            var comment = await _commentService.CreateComment(postId, userId, content);

            return comment;
        }

        [HttpGet("id/{postId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IEnumerable<CommentDto>> GetCommentsByPost(int postId)
        {
            var comments = await _commentService.GetCommentsByPost(postId);

            return comments;
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<CommentDto> UpdateComment(Comment comment)
        {
            var updatedComment = await _commentService.UpdateComment(comment);

            return updatedComment;
        }

        [HttpDelete("{commentId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<bool> DeletePost(int commentId)
        {
            var isDeleted = await _commentService.DeleteComment(commentId);

            return isDeleted;
        }
    }
}

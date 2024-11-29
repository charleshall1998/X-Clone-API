using Microsoft.AspNetCore.Mvc;
using X_Clone_API.Models.Dto;
using X_Clone_API.Services.Interfaces;

namespace X_Clone_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentController : ControllerBase
    {
        private ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CommentDto))]
        public async Task<ActionResult<CommentDto>> CreateComment(int postId, int userId, string content)
        {
            var comment = await _commentService.CreateComment(postId, userId, content);

            return Ok(comment);
        }

        [HttpGet("id/{postId}", Name = "GetCommentsByPost")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CommentDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<CommentDto>>> GetCommentsByPost(int postId)
        {
            var comments = await _commentService.GetCommentsByPost(postId);

            if (comments is null)
            {
                return BadRequest();
            }

            return Ok(comments);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CommentDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CommentDto>> UpdateComment(int commentId, string content)
        {
            var updatedComment = await _commentService.UpdateComment(commentId, content);

            if (updatedComment is null)
            {
                return BadRequest();
            }

            return Ok(updatedComment);
        }

        [HttpDelete("{commentId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<ActionResult<bool>> DeleteComment(int commentId)
        {
            var isDeleted = await _commentService.DeleteComment(commentId);

            return Ok(isDeleted);
        }
    }
}

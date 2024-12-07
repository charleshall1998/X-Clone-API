using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using X_Clone_API.Models.Data;
using X_Clone_API.Models.Dto;
using X_Clone_API.Services.Interfaces;

namespace X_Clone_API.Controllers
{
    [ApiController]
    [Route("api/comment")]
    public class CommentController : ControllerBase
    {
        private ICommentService _commentService;
        private IMapper _mapper;

        public CommentController(ICommentService commentService, IMapper mapper)
        {
            _commentService = commentService;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CommentDto>> CreateComment([FromBody] CreateCommentDto createCommentDto)
        {
            if (createCommentDto is null)
            {
                return BadRequest("Comment object is null");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest("Comment object is invalid");
            }

            var comment = _mapper.Map<Comment>(createCommentDto);

            var commentDto = await _commentService.CreateComment(comment);

            return CreatedAtRoute("CommentById", new { id = commentDto.Id }, commentDto);
        }

        [HttpGet("{commentId}", Name = "GetCommentById")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CommentDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CommentDto>> GetCommentById(int commentId)
        {
            var comments = await _commentService.GetCommentById(commentId);

            if (comments is null)
            {
                return BadRequest();
            }

            return Ok(comments);
        }

        [HttpGet("post/{postId}", Name = "GetCommentsByPost")]
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

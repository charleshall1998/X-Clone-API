using Microsoft.AspNetCore.Mvc;
using X_Clone_API.Models.Dto;
using X_Clone_API.Services.Interfaces;

namespace X_Clone_API.Controllers
{
    [ApiController]
    [Route("api/post")]
    public class PostController : ControllerBase
    {
        private IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PostDto))]
        public async Task<ActionResult<PostDto>> CreatePost(int userId, string content)
        {
            var post = await _postService.CreatePost(userId, content);

            return Ok(post);
        }

        [HttpGet("id/{userId}", Name = "GetPostsByUser")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PostDto>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<IEnumerable<PostDto>>> GetPostsByUser(int userId)
        {
            var posts = await _postService.GetPostsByUser(userId);

            if (posts is null)
            {
                return NotFound();
            }

            return Ok(posts);
        }

        [HttpGet("posts", Name = "GetAllPosts")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PostDto>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<IEnumerable<PostDto>>> GetAllPosts()
        {
            var posts = await _postService.GetAllPosts();

            if (posts is null)
            {
                return NotFound();
            }

            return Ok(posts);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        public async Task<ActionResult<int>> UpdatePostLikeCount(int postId)
        {
            var likeCount = await _postService.UpdatePostLikeCount(postId);

            return Ok(likeCount);
        }

        [HttpDelete("{postId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<ActionResult<bool>> DeletePost(int postId)
        {
            var isDeleted = await _postService.DeletePost(postId);

            return Ok(isDeleted);
        }
    }
}

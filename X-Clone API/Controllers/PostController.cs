using Microsoft.AspNetCore.Mvc;
using X_Clone_API.Models.Dto;
using X_Clone_API.Services.Interfaces;

namespace X_Clone_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : ControllerBase
    {
        private readonly ILogger<PostController> _logger;
        private IPostService _postService;

        public PostController(ILogger<PostController> logger, IPostService postService)
        {
            _logger = logger;
            _postService = postService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<PostDto> CreatePost(int userId, string content)
        {
            var post = await _postService.CreatePost(userId, content);

            return post;
        }

        [HttpGet("id/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IEnumerable<PostDto>> GetPostsByUser(int userId)
        {
            var posts = await _postService.GetPostsByUser(userId);

            return posts;
        }


        [HttpGet("posts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IEnumerable<PostDto>> GetAllUsers()
        {
            var posts = await _postService.GetPosts();

            return posts;
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<int> UpdatePostLikeCount(int postId)
        {
            var likeCount = await _postService.UpdatePostLikeCount(postId);

            return likeCount;
        }

        [HttpDelete("{postId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<bool> DeletePost(int postId)
        {
            var isDeleted = await _postService.DeletePost(postId);

            return isDeleted;
        }
    }
}

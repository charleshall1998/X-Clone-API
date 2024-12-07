using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using X_Clone_API.Models.Data;
using X_Clone_API.Models.Dto;
using X_Clone_API.Services.Interfaces;

namespace X_Clone_API.Controllers
{
    [ApiController]
    [Route("api/post")]
    public class PostController : ControllerBase
    {
        private IPostService _postService;
        private IMapper _mapper;

        public PostController(IPostService postService, IMapper mapper)
        {
            _postService = postService;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PostDto>> CreatePost([FromBody] CreatePostDto createPostDto)
        {
            if (createPostDto is null)
            {
                return BadRequest("Post object is null");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest("Post object is invalid");
            }

            var post = _mapper.Map<Post>(createPostDto);

            var createdPost = await _postService.CreatePost(post);

            return CreatedAtRoute("PostById", new { id = createdPost.Id }, createdPost);
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

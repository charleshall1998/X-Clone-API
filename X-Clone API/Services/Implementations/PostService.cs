using AutoMapper;
using X_Clone_API.Data.Repositories.Interfaces;
using X_Clone_API.Models.Data;
using X_Clone_API.Models.Dto;
using X_Clone_API.Services.Interfaces;

namespace X_Clone_API.Services.Implementations
{
    public class PostService : IPostService
    {
        private IPostRepository _postRepository;
        private IMapper _mapper;
        private ILogger _logger;

        public PostService(IPostRepository postRepository, IMapper mapper, ILogger logger)
        {
            _postRepository = postRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<PostDto> CreatePost(Post post)
        {
            _logger.LogInformation("Creating post for user ID: {userId}", post.UserId);

            //TODO: Validations

            var createdPost = await _postRepository.CreatePost(post);

            var postDto = _mapper.Map<PostDto>(post);

            _logger.LogInformation("Successfully created post with post ID {postId}", postDto.Id);

            return postDto;
        }

        public async Task<PostDto> GetPostById(int postId)
        {
            _logger.LogInformation("Retrieving posts for post ID: {postId}", postId);

            var post = await _postRepository.GetPostById(postId);

            var postDto = _mapper.Map<PostDto>(post);

            _logger.LogInformation("Successfully retrieved post with ID {postId}", postId);

            return postDto;
        }

        //TODO: Implement paging
        public async Task<IEnumerable<PostDto>> GetPostsByUser(int userId)
        {
            _logger.LogInformation("Retrieving posts for user ID: {userId}", userId);

            var posts = await _postRepository.GetPostsByUser(userId);

            var postDtos = _mapper.Map<IEnumerable<PostDto>>(posts);

            _logger.LogInformation("Successfully retrieved {count} posts", postDtos.Count());

            return postDtos;
        }

        public async Task<IEnumerable<PostDto>> GetAllPosts()
        {
            _logger.LogInformation("Retrieving posts");

            var posts = await _postRepository.GetAllPosts();

            var postDtos = _mapper.Map<IEnumerable<PostDto>>(posts);

            _logger.LogInformation("Successfully retrieved {count} posts", postDtos.Count());

            return postDtos;
        }

        public async Task<int> UpdatePostLikeCount(int postId)
        {
            _logger.LogInformation("Updating posts for post ID: {postId}", postId);

            var likeCount = await _postRepository.UpdatePostLikeCount(postId);

            _logger.LogInformation("Successfully updated like count to {count}", likeCount);

            return likeCount;
        }

        public async Task<bool> DeletePost(int postId)
        {
            _logger.LogInformation("Retrieving posts for post ID: {postId}", postId);

            var isDeleted = await _postRepository.DeletePost(postId);

            _logger.LogInformation("Successfully deleted post with post ID {postId}", postId);

            return isDeleted;
        }
    }
}

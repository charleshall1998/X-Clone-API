using AutoMapper;
using X_Clone_API.Models.Dto;
using X_Clone_API.Repository.Interfaces;
using X_Clone_API.Services.Interfaces;

namespace X_Clone_API.Services.Implementations
{
    public class PostService : IPostService
    {
        private IPostRepository _postRepository;
        private IMapper _mapper;

        public PostService(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<PostDto> CreatePost(int userId, string content)
        {
            //TODO: Validations
            var post = await _postRepository.CreatePost(userId, content);

            var postDto = _mapper.Map<PostDto>(post);

            return postDto;
        }

        //TODO: Implement paging
        public async Task<IEnumerable<PostDto>> GetPostsByUser(int userId)
        {
            var posts = await _postRepository.GetPostsByUser(userId);

            var postDtos = _mapper.Map<IEnumerable<PostDto>>(posts);

            return postDtos;
        }

        public async Task<IEnumerable<PostDto>> GetAllPosts()
        {
            var posts = await _postRepository.GetAllPosts();

            var postDtos = _mapper.Map<IEnumerable<PostDto>>(posts);

            return postDtos;
        }

        public async Task<int> UpdatePostLikeCount(int postId)
        {
            return await _postRepository.UpdatePostLikeCount(postId);
        }

        public async Task<bool> DeletePost(int postId)
        {
            return await _postRepository.DeletePost(postId);
        }
    }
}

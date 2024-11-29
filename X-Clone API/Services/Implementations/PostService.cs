using X_Clone_API.Models.Dto;
using X_Clone_API.Repository.Interfaces;
using X_Clone_API.Services.Interfaces;

namespace X_Clone_API.Services.Implementations
{
    public class PostService : IPostService
    {
        private IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<PostDto> CreatePost(int userId, string content)
        {
            //TODO: Validations

            return await _postRepository.CreatePost(userId, content);
        }

        //TODO: Implement paging
        public async Task<IEnumerable<PostDto>> GetPostsByUser(int userId)
        {
            return await _postRepository.GetPostsByUser(userId);
        }

        public async Task<IEnumerable<PostDto>> GetAllPosts()
        {
            return await _postRepository.GetAllPosts();
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

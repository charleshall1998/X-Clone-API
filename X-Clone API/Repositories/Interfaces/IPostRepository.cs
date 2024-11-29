using X_Clone_API.Models.Dto;

namespace X_Clone_API.Repository.Interfaces
{
    public interface IPostRepository
    {
        public Task<PostDto> CreatePost(int userId, string content);

        public Task<IEnumerable<PostDto>> GetAllPosts();

        public Task<IEnumerable<PostDto>> GetPostsByUser(int userId);

        public Task<int> UpdatePostLikeCount(int postId);

        public Task<bool> DeletePost(int postId);
    }
}

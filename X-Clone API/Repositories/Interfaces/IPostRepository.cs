using X_Clone_API.Data;

namespace X_Clone_API.Repository.Interfaces
{
    public interface IPostRepository
    {
        public Task<Post> CreatePost(int userId, string content);

        public Task<IEnumerable<Post>> GetAllPosts();

        public Task<IEnumerable<Post>> GetPostsByUser(int userId);

        public Task<int> UpdatePostLikeCount(int postId);

        public Task<bool> DeletePost(int postId);
    }
}

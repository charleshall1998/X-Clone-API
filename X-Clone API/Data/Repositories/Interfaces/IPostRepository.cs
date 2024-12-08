using X_Clone_API.Models.Data;

namespace X_Clone_API.Data.Repositories.Interfaces
{
    public interface IPostRepository
    {
        public Task<Post> CreatePost(Post post);

        public Task<IEnumerable<Post>> GetAllPosts();

        public Task<Post> GetPostById(int postId);

        public Task<IEnumerable<Post>> GetPostsByUser(int userId);

        public Task<int> UpdatePostLikeCount(int postId);

        public Task<bool> DeletePost(int postId);
    }
}

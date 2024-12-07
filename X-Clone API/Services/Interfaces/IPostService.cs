using X_Clone_API.Models.Data;
using X_Clone_API.Models.Dto;

namespace X_Clone_API.Services.Interfaces
{
    public interface IPostService
    {
        /// <summary>
        /// Creates a new post record.
        /// </summary>
        /// <param name="post">The post to be created</param>
        /// <returns>The new post record.</returns>
        public Task<PostDto> CreatePost(Post post);

        /// <summary>
        /// Gets all posts.
        /// </summary>
        /// <returns>All posts.</returns>
        public Task<IEnumerable<PostDto>> GetAllPosts();

        /// <summary>
        /// Gets all posts for a given user.
        /// </summary>
        /// <param name="userId">The id of the user to get the posts of.</param>
        /// <returns>All of the posts for a given user.</returns>
        public Task<IEnumerable<PostDto>> GetPostsByUser(int userId);

        /// <summary>
        /// Updates the post like count.
        /// </summary>
        /// <param name="postId">The id of the post being updated.</param>
        /// <returns>The total number of likes for the given post.</returns>
        public Task<int> UpdatePostLikeCount(int postId);

        /// <summary>
        /// Deletes a given post.
        /// </summary>
        /// <param name="postId">The id of the post to be deleted.</param>
        /// <returns>True if the deletion was successful, false if else.</returns>
        public Task<bool> DeletePost(int postId);
    }
}

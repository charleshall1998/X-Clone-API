using X_Clone_API.Models.Data;
using X_Clone_API.Models.Dto;

namespace X_Clone_API.Services.Interfaces
{
    public interface ICommentService
    {
        /// <summary>
        /// Creates a new comment record.
        /// </summary>
        /// <param name="comment">The comment to be created</param>
        /// <returns>The new comment.</returns>
        public Task<CommentDto> CreateComment(Comment comment);

        /// <summary>
        /// Gets comment by comment id.
        /// </summary>
        /// <param name="commentId">The id of the post to get comments for.</param>
        /// <returns>All comments for the given post.</returns>
        public Task<CommentDto> GetCommentById(int commentId);

        /// <summary>
        /// Gets all comments for a given post.
        /// </summary>
        /// <param name="postId">The id of the post to get comments for.</param>
        /// <returns>All comments for the given post.</returns>
        public Task<IEnumerable<CommentDto>> GetCommentsByPost(int postId);

        /// <summary>
        /// Updates the comment.
        /// </summary>
        /// <param name="id">The ID of the comment to be updated.</param>
        /// <param name="content">The content of the comment to be updated.</param>
        /// <returns>The updated comment.</returns>
        public Task<CommentDto> UpdateComment(int commentId, string content);

        /// <summary>
        /// Deletes a given comment.
        /// </summary>
        /// <param name="commentId">The id of the comment to be deleted.</param>
        /// <returns>True if the deletion was successful, false if else.</returns>
        public Task<bool> DeleteComment(int commentId);
    }
}

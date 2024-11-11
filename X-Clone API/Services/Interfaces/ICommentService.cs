﻿using X_Clone_API.Data;

namespace X_Clone_API.Services.Interfaces
{
    public interface ICommentService
    {
        /// <summary>
        /// Creates a new comment record.
        /// </summary>
        /// <param name="userId">The id of the user who is creating the comment.</param>
        /// <param name="content">The content of the comment.</param>
        /// <returns>The new comment.</returns>
        public Task<Comment> CreateComment(int userId, string content);

        /// <summary>
        /// Gets all comments for a given post.
        /// </summary>
        /// <param name="postId">The id of the post to get comments for.</param>
        /// <returns>All comments for the given post.</returns>
        public Task<IEnumerable<Comment>> GetCommentsByPost(int postId);

        /// <summary>
        /// Updates the comment.
        /// </summary>
        /// <param name="comment">The comment to update.</param>
        /// <returns>The updated comment.</returns>
        public Task<Comment> UpdateComment(Comment comment);

        /// <summary>
        /// Deletes a given comment.
        /// </summary>
        /// <param name="postId">The id of the comment to be deleted.</param>
        /// <returns>True if the deletion was successful, false if else.</returns>
        public Task<bool> DeleteComment(int postId);
    }
}
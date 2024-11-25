namespace X_Clone_API.Models.Dto
{
    public class CommentDto
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime CreatedAt { get; set; }

        public int PostId { get; set; }

        public int UserId { get; set; }
    }
}

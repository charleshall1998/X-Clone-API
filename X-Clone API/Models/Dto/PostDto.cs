namespace X_Clone_API.Models.Dto
{
    public class PostDto
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime CreatedAt { get; set; }

        public int LikeCount { get; set; }
    }
}

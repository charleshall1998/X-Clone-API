namespace X_Clone_API.Data
{
    public class Post
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime CreatedAt { get; set; }

        public int LikeCount { get; set; }

        //Foreign Key Property
        public int UserId { get; set; }

        //Navigation Property
        public User User { get; set; }
    }
}

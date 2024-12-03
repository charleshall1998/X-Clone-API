using System.ComponentModel.DataAnnotations;

namespace X_Clone_API.Models.Data
{
    public class Comment
    {
        public int Id { get; set; }

        [MaxLength(250)]
        public string Content { get; set; }

        public DateTime CreatedAt { get; set; }

        //Foreign Key Property
        public int UserId { get; set; }

        public int PostId { get; set; }

        //Navigation Property
        public User User { get; set; }

        public Post Post { get; set; }
    }
}

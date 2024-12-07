using System.ComponentModel.DataAnnotations;

namespace X_Clone_API.Models.Dto
{
    public class CreatePostDto
    {
        [Required(ErrorMessage = "Content required")]
        [StringLength(250, ErrorMessage = "Content cannot be longer than 250 characters")]
        public string Content { get; set; }

        [Required(ErrorMessage = "Created at required")]
        public DateTime CreatedAt { get; set; }

        [Required(ErrorMessage = "User ID required")]
        public int UserId { get; set; }
    }
}

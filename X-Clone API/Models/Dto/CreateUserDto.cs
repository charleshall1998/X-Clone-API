using System.ComponentModel.DataAnnotations;

namespace X_Clone_API.Models.Dto
{
    public class CreateUserDto
    {
        [Required(ErrorMessage = "Username required")]
        [StringLength(50, ErrorMessage = "username cannot be longer than 250 characters")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email required")]
        [EmailAddress(ErrorMessage = "Email format invalid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Email required")]
        public DateTime CreatedAt { get; set; }
    }
}

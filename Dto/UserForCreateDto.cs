using System.ComponentModel.DataAnnotations;

namespace api.Dto
{
    public class UserForCreateDto
    {
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [MaxLength(10, ErrorMessage = "Phone number should not be more than 10 digits")]
        public string PhoneNumber { get; set; }
        public string Password { get; set; }

        [Required(ErrorMessage = "Role is a requird field")]
        public string Role { get; set; }
    }
}
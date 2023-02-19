using PracticumHomeWork.Base.Dto;
using System.ComponentModel.DataAnnotations;

namespace PracticumHomeWork.Dto.Dtos
{
    public class UserDto : BaseDto
    {
        [EmailAddress(ErrorMessage = "Email address is not valid.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

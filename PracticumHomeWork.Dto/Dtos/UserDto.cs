using PracticumHomeWork.Base.Dto;
using System.ComponentModel.DataAnnotations;

namespace PracticumHomeWork.Dto.Dtos
{
    public class UserDto : BaseDto
    {
        [Required]
        [MaxLength(125)]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [MaxLength(500)]
        public string Name { get; set; }

        [Required]
        [EmailAddressAttribute]
        [MaxLength(500)]
        public string Email { get; set; }

        [Required]
        public string Role { get; set; }


        [Display(Name = "Last Activity")]
        public DateTime LastActivity { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace PracticumHomeWork.Dto.Models
{
    public class UpdatePasswordRequest
    {
        [Required]
        public string OldPassword { get; set; }

        [Required]
        public string NewPassword { get; set; }
    }
}

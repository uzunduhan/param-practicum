using PracticumHomeWork.Base;
using System.ComponentModel.DataAnnotations;

namespace PracticumHomeWork.Dto.Models
{
    public class TokenRequest
    {
        [Required]
        [MaxLength(125)]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}

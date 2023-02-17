using System.ComponentModel.DataAnnotations;

namespace PracticumHomeWork.DTOs
{
    public class UpdateUserModel
    {
        [EmailAddress(ErrorMessage = "Email address is not valid.")]
        public string Email { get; set; }
    }
}

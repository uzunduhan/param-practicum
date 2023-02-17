using FluentValidation;
using PracticumHomeWork.DTOs;

namespace PracticumHomeWork.Validations
{
    public class UpdateUserValidations : AbstractValidator<UpdateUserModel>
    {
        public UpdateUserValidations()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("email cannot be empty").MinimumLength(7).WithMessage("email character count must be greater than 7");
        }
    }
}

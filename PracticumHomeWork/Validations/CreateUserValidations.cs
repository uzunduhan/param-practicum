using FluentValidation;
using PracticumHomeWork.DTOs;

namespace PracticumHomeWork.Validations
{
    public class CreateUserValidations : AbstractValidator<CreateUserModel>
    {
        public CreateUserValidations()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("email cannot be empty").MinimumLength(7).WithMessage("email character count must be greater than 7");
            RuleFor(x => x.Password).NotEmpty().WithMessage("password cannot be empty").MinimumLength(6).WithMessage("password character count must be greater than 6");
        }
    }
}

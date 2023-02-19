using FluentValidation;
using PracticumHomeWork.Dto.Dtos;

namespace PracticumHomeWork.Validations
{
    public class UserDtoValidator : AbstractValidator<UserDto>
    {
        public UserDtoValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("email cannot be empty").MinimumLength(7).WithMessage("email character count must be greater than 7");
            RuleFor(x => x.Password).NotEmpty().WithMessage("password cannot be empty").MinimumLength(6).WithMessage("password character count must be greater than 6");
        }
    }
}

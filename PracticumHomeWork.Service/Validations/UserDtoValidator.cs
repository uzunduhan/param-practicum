using FluentValidation;
using PracticumHomeWork.Dto.Dtos;

namespace PracticumHomeWork.Service.Validations
{
    public class UserDtoValidator : AbstractValidator<UserDto>
    {
        public UserDtoValidator()
        {
            RuleFor(x => x.Email).NotEmpty().MinimumLength(7);
            RuleFor(x => x.Password).NotEmpty().MinimumLength(6);
        }
    }
}

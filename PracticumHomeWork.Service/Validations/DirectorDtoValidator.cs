using FluentValidation;
using PracticumHomeWork.Dto.Dtos;

namespace PracticumHomeWork.Service.Validations
{
    public  class DirectorDtoValidator : AbstractValidator<DirectorDto>
    {
        public DirectorDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MinimumLength(4);
            RuleFor(x => x.SurName).NotEmpty().MinimumLength(4);
            RuleFor(x => x.Birthday).NotEmpty().LessThanOrEqualTo(DateTime.Now.Date);

        }
    }
}

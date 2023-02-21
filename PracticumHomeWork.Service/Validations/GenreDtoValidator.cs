using FluentValidation;
using PracticumHomeWork.Dto.Dtos;

namespace PracticumHomeWork.Service.Validations
{
    public class GenreDtoValidator : AbstractValidator<GenreDto>
    {
        public GenreDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MinimumLength(4);
        }
    }
}

using FluentValidation;
using PracticumHomeWork.Dto.Dtos;

namespace PracticumHomeWork.Service.Validations
{
    public class MovieDtoValidator : AbstractValidator<MovieDto>
    {
        public MovieDtoValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MinimumLength(4);
            RuleFor(x => x.Duration).NotEmpty().GreaterThanOrEqualTo(30);
            RuleFor(x => x.ReleaseDate).NotEmpty().LessThanOrEqualTo(DateTime.Now.Date);
            RuleFor(x => x.GenreId).NotEmpty().GreaterThan(0);
            RuleFor(x => x.RatingScore).NotEmpty().LessThanOrEqualTo(10).GreaterThanOrEqualTo(0);
        }
    }
}

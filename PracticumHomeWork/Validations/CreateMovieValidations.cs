using FluentValidation;
using PracticumHomeWork.DTOs;

namespace PracticumHomeWork.Validations
{
    public class CreateMovieValidations : AbstractValidator<CreateMovieModel>
    {
        public CreateMovieValidations()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("movie title cannot empty").MinimumLength(4).WithMessage("movie title character count must be greater than 4");
            RuleFor(x => x.Duration).NotEmpty().WithMessage("movie duration cannot empty").GreaterThanOrEqualTo(30).WithMessage("duration must be greater than 30 minutes");
            RuleFor(x => x.ReleaseDate).NotEmpty().WithMessage("movie release date cannot empty").LessThanOrEqualTo(DateTime.Now.Date).WithMessage("movie release date must be less than now");
            RuleFor(x => x.GenreId).NotEmpty().WithMessage("movie genre id cannot empty").GreaterThan(0).WithMessage("genre id must be greater than 0");
        }
    }
}

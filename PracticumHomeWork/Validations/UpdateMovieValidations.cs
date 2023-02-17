using FluentValidation;
using PracticumHomeWork.DTOs;

namespace PracticumHomeWork.Validations
{
    public class UpdateMovieValidations : AbstractValidator<UpdateMovieModel>
    {
        public UpdateMovieValidations()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("movie title cannot empty").MinimumLength(4).WithMessage("movie title character count must be greater than 4");
            RuleFor(x => x.GenreId).NotEmpty().WithMessage("movie genre id cannot empty").GreaterThan(0).WithMessage("genre id must be greater than 0");
        }
  
    }
}

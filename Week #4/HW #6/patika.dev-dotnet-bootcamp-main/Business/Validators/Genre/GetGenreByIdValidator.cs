using FluentValidation;
using WebApi.Business.Application.GenreOperations.GetGenreDetail;

namespace WebApi.Business.Validators.Genre
{
    public class GetGenreByIdValidator : AbstractValidator<GetGenreDetailQuery>
    {
        public GetGenreByIdValidator()

        {
            RuleFor(b => b.GenreId)
                .NotEmpty()
                .WithMessage("Genre ID is required for getting genre by ID.");

        }
    }
}

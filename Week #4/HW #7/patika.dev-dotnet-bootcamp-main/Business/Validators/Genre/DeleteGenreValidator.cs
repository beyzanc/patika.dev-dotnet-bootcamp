using FluentValidation;
using WebApi.Business.Application.GenreOperations.DeleteGenre;

namespace WebApi.Business.Validators.Genre
{
    public class DeleteGenreValidator : AbstractValidator<DeleteGenreCommand>
    {
        public DeleteGenreValidator()
        {
            RuleFor(b => b.GenreId)
                .NotEmpty()
                .WithMessage("Genre ID is required for deletion.");

        }
    }
}

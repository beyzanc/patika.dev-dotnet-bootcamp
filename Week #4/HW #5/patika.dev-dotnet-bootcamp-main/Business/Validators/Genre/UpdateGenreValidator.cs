using FluentValidation;
using WebApi.Business.Application.AuthorOperations.UpdateAuthor;
using WebApi.Business.Application.GenreOperations.UpdateGenre;

namespace WebApi.Business.Validators.Genre
{
    public class UpdateGenreValidator : AbstractValidator<UpdateGenreCommand>
    {
        public UpdateGenreValidator()

        {

            RuleFor(b => b.Model.Name)
                .NotEmpty().WithMessage("Name field is required.");

            RuleFor(b => b.Model.IsActive)
                .NotEmpty().WithMessage("The field is required.");

        }
    }
}

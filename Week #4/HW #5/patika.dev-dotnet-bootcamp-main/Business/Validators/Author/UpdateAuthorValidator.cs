using FluentValidation;
using WebApi.Business.Application.AuthorOperations.UpdateAuthor;

namespace WebApi.Business.Validators.Author
{
    public class UpdateAuthorValidator : AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorValidator()

        {

            RuleFor(b => b.Model.Name)
                .NotEmpty().WithMessage("Name field is required.");

            RuleFor(b => b.Model.Surname)
                .NotEmpty().WithMessage("Surname field is required.");

        }
    }
}

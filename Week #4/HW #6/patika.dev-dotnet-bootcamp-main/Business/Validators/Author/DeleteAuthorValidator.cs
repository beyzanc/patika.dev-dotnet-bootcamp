using FluentValidation;
using WebApi.Business.Application.AuthorOperations.DeleteAuthor;

namespace WebApi.Business.Validators.Author
{
    public class DeleteAuthorValidator : AbstractValidator<DeleteAuthorCommand>
    {
        public DeleteAuthorValidator()
        {
            RuleFor(b => b.AuthorId)
                .NotEmpty()
                .WithMessage("Author ID is required for deletion.");

        }
    }
}

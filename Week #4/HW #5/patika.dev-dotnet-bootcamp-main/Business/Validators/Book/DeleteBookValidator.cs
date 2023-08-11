using FluentValidation;
using WebApi.Business.Application.BookOperations.DeleteBook;

namespace WebApi.Business.Validators.Book
{
    public class DeleteBookValidator : AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookValidator()
        {
            RuleFor(b => b.BookId)
                .NotEmpty()
                .WithMessage("Book ID is required for deletion.");

        }
    }
}

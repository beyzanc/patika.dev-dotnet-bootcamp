using FluentValidation;
using WebApi.Business.BookOperations.DeleteBook;

namespace WebApi.Business.Validators
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

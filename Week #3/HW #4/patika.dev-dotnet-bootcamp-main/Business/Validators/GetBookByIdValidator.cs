using FluentValidation;
using WebApi.Business.BookOperations.GetBookDetail;

namespace WebApi.Business.Validators
{
    public class GetBookByIdValidator : AbstractValidator<GetByIdQuery>
    {
        public GetBookByIdValidator()
        
        {
            RuleFor(b => b.BookId)
                .NotEmpty()
                .WithMessage("Book ID is required for getting book by ID.");
        
        }
    }
}

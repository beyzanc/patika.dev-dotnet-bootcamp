using FluentValidation;
using WebApi.Business.Application.BookOperations.GetBookDetail;

namespace WebApi.Business.Validators.Book
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

using FluentValidation;
using WebApi.Business.Application.BookOperations.UpdateBook;

namespace WebApi.Business.Validators.Book
{
    public class UpdateBookValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookValidator()

        {

            RuleFor(b => b.Model.GenreId)
                .NotEmpty().WithMessage("Id field is required.")
                .GreaterThan(0).WithMessage("Id must be greater than 0.");

            RuleFor(b => b.Model.Title)
                .NotEmpty().WithMessage("Title is required")
                .MinimumLength(10).WithMessage("Title length must be greater than 0.");

        }
    }
}

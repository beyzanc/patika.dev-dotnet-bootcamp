using FluentValidation;
using WebApi.Business.Application.AuthorOperations.GetAuthorDetail;

namespace WebApi.Business.Validators.Author
{
    public class GetAuthorByIdValidator : AbstractValidator<GetAuthorDetailQuery>
    {
        public GetAuthorByIdValidator()

        {
            RuleFor(b => b.AuthorId)
                .NotEmpty()
                .WithMessage("Author ID is required for getting author by ID.");

        }
    }

}

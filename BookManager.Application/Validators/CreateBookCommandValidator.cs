using BookManager.Application.Commands.CreateBook;
using FluentValidation;

namespace BookManager.Application.Validators
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(book => book.Author)
                .NotNull()
                .MaximumLength(100)
                .WithMessage("Value not null and maximum is 100 lenght");

            RuleFor(book => book.Title)
                .NotNull()
                .MaximumLength(100)
                .WithMessage("Value not null and maximum is 100 lenght");
        }
    }
}

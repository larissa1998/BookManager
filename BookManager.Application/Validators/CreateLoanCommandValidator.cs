using BookManager.Application.Commands.CreateLoan;
using FluentValidation;

namespace BookManager.Application.Validators
{
    public class CreateLoanCommandValidator : AbstractValidator<CreateLoanCommand>
    {
        public CreateLoanCommandValidator() 
        {
            RuleFor(loan => loan.IdUser)
             .NotNull();

            RuleFor(loan => loan.IdBook)
             .NotNull();
        }
    }
}

using BookManager.Application.Commands.CreateUser;
using FluentValidation;

namespace BookManager.Application.Validators
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand> 
    {
        public CreateUserCommandValidator() 
        {
            RuleFor(user => user.Name)
             .NotNull()
             .MaximumLength(100)
             .WithMessage("Value not null");

            RuleFor(user => user.Email)
             .NotNull()
             .EmailAddress()
             .WithMessage("Email is not a valid email address");
        }
        
    }
}

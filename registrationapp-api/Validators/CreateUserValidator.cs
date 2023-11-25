using FluentValidation;
using registrationapp.DTO;

namespace registrationapp.Validators
{
    public class CreateUserValidator : AbstractValidator<UserDto>
    {
        public CreateUserValidator()
        {
            RuleFor(a => a.Login)
                .NotEmpty()
                .Matches("^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$")
                .MaximumLength(255);

            RuleFor(a => a.Password)
                .NotEmpty()
                .Matches("(?=.*[0-9A-Z])(?=.*[A-Z])(?=.*[0-9])")
                .MaximumLength(255);
        }
    }
}

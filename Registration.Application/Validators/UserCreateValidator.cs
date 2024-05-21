using FluentValidation;
using Registration.Application.Commands;


namespace Registration.Application.Validators
{
    public class UserCreateValidator : AbstractValidator<UserCreateCommand>
    {
        public UserCreateValidator()
        {
            RuleFor(x => x.FirstName)
                       .NotEmpty().WithMessage("First name is required")
                       .MaximumLength(20).WithMessage("First name cannot be longer than 20 characters")
                       .Matches(@"^[\u0621-\u064A\u0660-\u0669a-zA-Z\s]*$")
                       .WithMessage("First name must contain only Arabic or English letters and spaces");

            RuleFor(x => x.MiddleName)
                .MaximumLength(40).WithMessage("Middle name cannot be longer than 40 characters")
                .Matches(@"^[\u0621-\u064A\u0660-\u0669a-zA-Z\s]*$")
                .WithMessage("Middle name must contain only Arabic or English letters and spaces");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name is required")
                .MaximumLength(20).WithMessage("Last name cannot be longer than 20 characters")
                .Matches(@"^[\u0621-\u064A\u0660-\u0669a-zA-Z\s]*$")
                .WithMessage("Last name must contain only Arabic or English letters and spaces");

            RuleFor(x => x.BirthDate)
                .NotEmpty().WithMessage("Birth date is required")
                .Must(BeAtLeast20YearsOld)
                .WithMessage("You must be at least 20 years old");

            RuleFor(x => x.MobileNumber)
                .NotEmpty().WithMessage("Mobile number is required")
                .Matches(@"^\+\d{12}$")
                .WithMessage("Mobile number must be in the format +021XXXXXXXXXXX");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress()
                .WithMessage("Invalid email address");
            RuleForEach(x => x.Addresses).SetValidator(new AddressValidator());
        }
        private bool BeAtLeast20YearsOld(DateTime date)
        {
            return date <= DateTime.Now.AddYears(-20);
        }
    }
}

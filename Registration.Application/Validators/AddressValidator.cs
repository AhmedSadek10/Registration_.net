using FluentValidation;
using Registration.Application.DTO;


namespace Registration.Application.Validators
{
    public class AddressValidator : AbstractValidator<AddressDto>
    {
        public AddressValidator()
        {
            RuleFor(x => x.Governate)
                .NotEmpty()
                .WithMessage("Governate is required");

            RuleFor(x => x.City)
                .NotEmpty()
                .WithMessage("City is required");

            RuleFor(x => x.Street).
                NotEmpty()
                .WithMessage("Street is required")
                .MaximumLength(200);

            RuleFor(x => x.BuildingNumber)
                .NotEmpty()
                .WithMessage("Building Number is required");

            RuleFor(x => x.FlatNumber).
                NotEmpty()
                .WithMessage("Flat Number is required");
        }
    }
}

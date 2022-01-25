using FluentValidation;

namespace Person.Application.Features.People_PhoneNumber.Commands.CreatePerson_PhoneNumber
{
    public class CreatePersonPhoneNumberCommandValidator : AbstractValidator<CreatePersonPhoneNumberCommandVm>
    {
        public CreatePersonPhoneNumberCommandValidator()
        {
            RuleFor(p => p.Person_Id)
                .NotEmpty().WithMessage("{Person_Id} is required.")
                .NotNull()
                .GreaterThan(0).WithMessage("{Person_Id} should be greater than zero.");

            RuleFor(p => p.Type)
                .NotEmpty().WithMessage("{Type} is required.")
                .NotNull()
                .MaximumLength(10).WithMessage("{Type} should not exceed 10 characters.");

            RuleFor(p => p.CountryCode)
                .NotEmpty().WithMessage("{CountryCode} is required.")
                .NotNull()
                .GreaterThan(0).WithMessage("{CountryCode} should be greater than zero.");

            RuleFor(p => p.AreaCode)
                .NotEmpty().WithMessage("{AreaCode} is required.")
                .NotNull()
                .GreaterThan(0).WithMessage("{AreaCode} should be greater than zero.")
                .LessThan(1000).WithMessage("{AreaCode} should be less than 1000.");

            RuleFor(p => p.TelephoneNumber)
                .NotEmpty().WithMessage("{TelephoneNumber} is required.")
                .NotNull()
                .GreaterThan(0).WithMessage("{TelephoneNumber} should be greater than zero.")
                .LessThan(10000000).WithMessage("{TelephoneNumber} should be less than 10000000.");

        }
    }
}

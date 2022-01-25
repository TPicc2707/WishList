using FluentValidation;

namespace Person.Application.Features.People_Address.Commands.CreatePerson_Address
{
    public class CreatePersonAddressCommandValidator : AbstractValidator<CreatePersonAddressCommandVm>
    {
        public CreatePersonAddressCommandValidator()
        {
            RuleFor(p => p.Person_Id)
                .NotEmpty().WithMessage("{Person_Id} is required.")
                .NotNull()
                .GreaterThan(0).WithMessage("{Person_Id} should be greater than zero.");

            RuleFor(p => p.Street)
                .NotEmpty().WithMessage("{Street} is required.")
                .NotNull()
                .MaximumLength(100).WithMessage("{Street} must not exceed 100 characters");

            RuleFor(p => p.City)
                .NotEmpty().WithMessage("{City} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{City} must not exceed 50 characters");


            RuleFor(p => p.State)
                .NotEmpty().WithMessage("{State} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{State} must not exceed 50 characters");


            RuleFor(p => p.ZipCode)
                .NotEmpty().WithMessage("{ZipCode} is required.")
                .NotNull()
                .GreaterThan(0).WithMessage("{ZipCode} should be greater than zero.")
                .LessThan(100000).WithMessage("{ZipCode} should be less than 100000.");

        }
    }
}

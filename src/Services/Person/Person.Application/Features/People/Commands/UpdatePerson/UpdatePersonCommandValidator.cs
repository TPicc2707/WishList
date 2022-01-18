using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Application.Features.People.Commands.UpdatePerson
{
    public class UpdatePersonCommandValidator : AbstractValidator<UpdatePersonCommandVm>
    {
        public UpdatePersonCommandValidator()
        {
            RuleFor(p => p.Title)
                .MaximumLength(5).WithMessage("{Title} must not exceed 5 characters");

            RuleFor(p => p.FirstName)
                .NotEmpty().WithMessage("{FirstName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{FirstName} must not exceed 50 characters");

            RuleFor(p => p.MiddleInitial)
                .MaximumLength(1).WithMessage("{MiddleInitial} must not exceed 1 characters");

            RuleFor(p => p.LastName)
                .NotEmpty().WithMessage("{LastName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{LastName} must not exceed 50 characters");

            RuleFor(p => p.Gender)
                .NotEmpty().WithMessage("{Gender} is required.")
                .NotNull()
                .MaximumLength(6).WithMessage("{Gender} must not exceed 6 characters");

            RuleFor(p => p.DateOfBirth)
                .NotEmpty().WithMessage("{DateOfBirth} is required.");

        }
    }
}

using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novel.ViewModels.System.Users.Validator
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required.")
                .MaximumLength(200).WithMessage("First name cannot over 200 characters");

            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required.")
                .MaximumLength(200).WithMessage("Last name cannot over 200 characters");

            RuleFor(x => x.Birthday).GreaterThan(DateTime.Now.AddYears(-120)).WithMessage("Birthday cannot greater than 120 years old")
                .LessThan(DateTime.Now.AddYears(-10)).WithMessage("Birthday must greater than 10 years old");

            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Phone number is required.")
                .Matches(@"^(\+)?(\d{1,2})?[( .-]*(\d{3})[) .-]*(\d{3,4})[ .-]?(\d{4})$")
                .WithMessage("Phone number format not match");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Email address is required.")
                .Matches(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$")
                .WithMessage("Email address format not match");

            RuleFor(x => x.UserName).NotEmpty().WithMessage("Username is required.")
                .MaximumLength(200).WithMessage("Username cannot over 200 characters");

            RuleFor(x => x).Custom((request, context) =>
            {
                if(request.Password != request.ConfirmPassword)
                {
                    context.AddFailure("Confirm password is not match.");
                }
            });

        }
    }
}

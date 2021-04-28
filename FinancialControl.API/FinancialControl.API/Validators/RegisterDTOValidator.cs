using FinancialControl.API.DTOs;
using FluentValidation;

namespace FinancialControl.API.Validators
{
    public class RegisterDTOValidator : AbstractValidator<RegisterDTO>
    {
        public RegisterDTOValidator()
        {
            RuleFor(r => r.UserName)
               .NotNull().WithMessage("Enter user name")
               .MinimumLength(3).WithMessage("User name too short. Provide a more meaningful name")
               .MaximumLength(50).WithMessage("User name too long");

            RuleFor(r => r.TaxNumber)
               .NotNull().WithMessage("Enter tax number")
               .MinimumLength(1).WithMessage("Tax number too short. Provide the full tax number")
               .MaximumLength(20).WithMessage("Tax number too long");

            RuleFor(r => r.Occupation)
              .NotNull().WithMessage("Enter user occupation")
              .MinimumLength(3).WithMessage("User occupation too short. Provide a more meaningful name")
              .MaximumLength(30).WithMessage("User occupation too long");

            RuleFor(r => r.Photograph)
              .NotNull().WithMessage("Enter user photo");

            RuleFor(r => r.Email)
              .NotNull().WithMessage("Enter user email")
              .MinimumLength(10).WithMessage("User email too short")
              .MaximumLength(50).WithMessage("User email too long")
              .EmailAddress().WithMessage("Invalid email");

            RuleFor(r => r.Password)
              .NotNull().WithMessage("Enter user password")
              .MinimumLength(6).WithMessage("Password too short")
              .MaximumLength(50).WithMessage("Password too long");
        }
    }
}

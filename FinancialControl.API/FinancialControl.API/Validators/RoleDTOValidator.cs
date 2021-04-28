using FinancialControl.API.DTOs;
using FluentValidation;

namespace FinancialControl.API.Validators
{
    public class RoleDTOValidator : AbstractValidator<RoleDTO>
    {
        public RoleDTOValidator()
        {
            RuleFor(r => r.Name)
                .NotNull().WithMessage("Enter role name")
                .MinimumLength(3).WithMessage("Role name too short. Provide a more meaningful name")
                .MaximumLength(50).WithMessage("Role name too long");

            RuleFor(r => r.Description)
                .NotNull().WithMessage("Enter role description")
                .MinimumLength(3).WithMessage("Role description too short. Provide a more meaningful name")
                .MaximumLength(50).WithMessage("Role description too long");
        }
    }
}

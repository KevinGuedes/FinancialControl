using FinancialControl.BLL.Models;
using FluentValidation;

namespace FinancialControl.API.Validators
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(c => c.Name)
                .NotNull().WithMessage("Enter category name")
                .MinimumLength(3).WithMessage("Category name too short. Provide a more meaningful name")
                .MaximumLength(50).WithMessage("Category name too long");

            RuleFor(c => c.Icon)
                .NotNull().WithMessage("Enter category icon")
                .MinimumLength(1).WithMessage("Icon code too short")
                .MaximumLength(15).WithMessage("Icon code too long");

            RuleFor(c => c.TypeId)
                .Must(type => type != 0).WithMessage("Select the category type");
        }
    }
}

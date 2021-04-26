using FinancialControl.BLL.Models;
using FluentValidation;
using System.Collections.Generic;

namespace FinancialControl.API.Validators
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        
        public CategoryValidator()
        {
            RuleFor(c => c.Name)
                .NotNull().WithMessage("Enter category name")
                .MinimumLength(1).WithMessage("Short category name. Provide a more meaningful name")
                .MaximumLength(50).WithMessage("Category name too long");

            RuleFor(c => c.Icon)
                .NotNull().WithMessage("Enter category icon")
                .MinimumLength(1).WithMessage("Invalid icon code")
                .MaximumLength(50).WithMessage("Icon code too long");

            RuleFor(c => c.TypeId)
                .Must(type => type != 0).WithMessage("Invalid type");
        }
    }
}

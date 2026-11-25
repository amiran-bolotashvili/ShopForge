using FluentValidation;

namespace ShopForge.Catalog.Application.Categories.Commands.CreateCategory;

public class CreateCategoryCommandValidator 
    : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Category name is required.")
            .MaximumLength(100).WithMessage("Category name must not exceed 100 characters.");

        RuleFor(x => x.ParentId)
            .NotEqual(Guid.Empty)
            .When(x => x.ParentId.HasValue);
    }
}

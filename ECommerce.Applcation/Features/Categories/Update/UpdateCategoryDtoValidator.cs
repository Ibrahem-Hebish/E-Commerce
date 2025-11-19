using ECommerce.Application.Dtos.Categories;

namespace ECommerce.Application.Features.Categories.Update;

public class UpdateCategoryDtoValidator : AbstractValidator<UpdateCategoryDto>
{
    public UpdateCategoryDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Category name is required.")
            .MaximumLength(100).WithMessage("Category name must not exceed 100 characters.")
            .When(x => x.Description is not null);

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Category description is required.")
            .MaximumLength(500).WithMessage("Category description must not exceed 500 characters.")
            .When(x => x.Description is not null);

        RuleFor(x => x)
            .Must(dto => dto.Name is not null || dto.Description is not null)
            .WithMessage("At least one field (Name or Description) must be provided for update.");
    }
}

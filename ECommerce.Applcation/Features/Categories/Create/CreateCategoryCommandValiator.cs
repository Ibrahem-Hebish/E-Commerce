namespace ECommerce.Application.Features.Categories.Create;

public class CreateCategoryCommandValiator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValiator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name can not be empty.")
            .NotNull().WithMessage("Name can not be null.")
            .MaximumLength(50).WithMessage("Name can not exceed 50 chars.");

        RuleFor(x => x.Description)
           .NotEmpty().WithMessage("Description can not be empty.")
           .NotNull().WithMessage("Description can not be null.")
           .MaximumLength(500).WithMessage("Description can not exceed 500 chars.");
    }
}

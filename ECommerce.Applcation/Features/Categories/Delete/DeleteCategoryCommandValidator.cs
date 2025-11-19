namespace ECommerce.Application.Features.Categories.Delete;

public class DeleteCategoryCommandValidator : AbstractValidator<DeleteCategoryCommand>
{
    public DeleteCategoryCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotNull().WithMessage("Id can not be null.")
            .NotEmpty().WithMessage("Id can not be empty.");
    }
}

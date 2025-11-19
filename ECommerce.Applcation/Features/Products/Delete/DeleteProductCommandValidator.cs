namespace ECommerce.Application.Features.Products.Delete;

public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
{
    public DeleteProductCommandValidator()
    {
        RuleFor(x => x.Id)
           .NotEmpty().WithMessage("Id can not be empty")
           .NotNull().WithMessage("Id can not be null.");

    }
}
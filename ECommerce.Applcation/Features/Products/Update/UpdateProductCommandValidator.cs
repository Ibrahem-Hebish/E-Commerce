namespace ECommerce.Application.Features.Products.Update;

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(x => x.Id)
          .NotEmpty().WithMessage("Id can not be empty")
          .NotNull().WithMessage("Id can not be null.");

        RuleFor(x => x.Name)
            .MaximumLength(100)
            .When(x => !String.IsNullOrWhiteSpace(x.Name))
            .WithMessage("Name can not exceed 100 chars.");

        RuleFor(x => x.Description)
            .MaximumLength(500)
            .When(x => !String.IsNullOrWhiteSpace(x.Description))
            .WithMessage("Descrition can not exceed 500 chars.");

        RuleFor(x => x.Price)
            .GreaterThan(0)
            .When(x => x.Price is not null)
            .WithMessage("Price can not be 0 or negative.");

        RuleFor(x => x.StockQuantity)
            .GreaterThanOrEqualTo(0)
            .When(x => x.StockQuantity is not null)
            .WithMessage("Stock quantity can not be negative.");
    }
}
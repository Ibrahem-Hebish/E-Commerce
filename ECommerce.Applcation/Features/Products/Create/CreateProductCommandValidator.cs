namespace ECommerce.Application.Features.Products.Create;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Product name is required.")
            .MaximumLength(100).WithMessage("Product name must not exceed 100 characters.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Product description is required.")
            .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Price must be greater than zero.");

        RuleFor(x => x.StockQuantity)
            .GreaterThanOrEqualTo(0).WithMessage("Stock quantity cannot be negative.");

        // Discount percentage only makes sense if HasDiscount = true
        RuleFor(x => x.DiscountPercentage)
            .InclusiveBetween(1, 100)
            .When(x => x.HasDiscount)
            .WithMessage("Discount percentage must be between 1 and 100 when discount is enabled.");

        // If HasDiscount = false, discount percentage must be 0
        RuleFor(x => x.DiscountPercentage)
            .Equal(0)
            .When(x => !x.HasDiscount)
            .WithMessage("Discount percentage must be 0 if discount is disabled.");

    }
}

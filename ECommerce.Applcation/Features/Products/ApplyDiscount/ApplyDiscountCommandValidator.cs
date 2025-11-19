namespace ECommerce.Application.Features.Products.ApplyDiscount;

public class ApplyDiscountCommandValidator : AbstractValidator<ApplyDiscountCommand>
{
    public ApplyDiscountCommandValidator()
    {
        RuleFor(x => x.ProductId)
            .NotEmpty()
            .WithMessage("Product ID is required.");

        RuleFor(x => x.DiscountPercentage)
            .InclusiveBetween(0, 100)
            .WithMessage("Discount percentage must be between 0 and 100.");
    }
}

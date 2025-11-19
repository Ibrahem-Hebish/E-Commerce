namespace ECommerce.Application.Features.Products.ReseatDiscount;

public class ReseatDiscountCommandValidator : AbstractValidator<ReseatDiscountCommand>
{
    public ReseatDiscountCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Product ID is required.");

    }
}
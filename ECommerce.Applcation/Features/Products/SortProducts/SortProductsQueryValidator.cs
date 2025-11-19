namespace ECommerce.Application.Features.Products.SortProducts;

public class SortProductsQueryValidator : AbstractValidator<SortProductsQuery>
{
    public SortProductsQueryValidator()
    {
        RuleFor(x => x.SortBy)
            .IsInEnum().WithMessage("Invalid SortBy value.");

        RuleFor(x => x.SortDirection)
            .IsInEnum().WithMessage("Invalid SortDirection value.");
    }
}

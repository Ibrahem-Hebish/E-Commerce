
namespace ECommerce.Application.Features.Products.Paginate;

public class PaginateProductsQueryValidator : AbstractValidator<PaginateProductsQuery>
{
    public PaginateProductsQueryValidator()
    {
        RuleFor(x => x.PaginationDirection)
            .NotNull().WithMessage("Direction can not be null.")
            .NotEmpty().WithMessage("Direction can not be empty.");
    }
}
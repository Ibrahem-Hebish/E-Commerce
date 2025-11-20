namespace ECommerce.Application.Features.Orders.Paginate;

public class PaginateOrdersQueryValidator : AbstractValidator<PaginateOrdersQuery>
{
    public PaginateOrdersQueryValidator()
    {
        RuleFor(x => x.PaginationDirection)
                        .IsInEnum().WithMessage("Invalid pagination direction.");
    }
}


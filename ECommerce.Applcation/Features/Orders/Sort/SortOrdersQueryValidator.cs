namespace ECommerce.Application.Features.Orders.Sort;

public class SortOrdersQueryValidator : AbstractValidator<SortOrdersQuery>
{
    public SortOrdersQueryValidator()
    {
        RuleFor(x => x.SortBy)
            .IsInEnum().WithMessage("Invalid sort by value.");

        RuleFor(x => x.Direction)
            .IsInEnum().WithMessage("Invalid sort direction value.");
    }
}

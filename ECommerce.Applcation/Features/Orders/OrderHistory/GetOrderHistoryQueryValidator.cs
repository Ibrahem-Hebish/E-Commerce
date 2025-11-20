namespace ECommerce.Application.Features.Orders.OrderHistory;

public class GetOrderHistoryQueryValidator : AbstractValidator<GetOrderHistoryQuery>
{
    public GetOrderHistoryQueryValidator()
    {
        RuleFor(x => x.OrderId)
            .NotEmpty().WithMessage("Order ID is required.")
            .NotEqual(Guid.Empty).WithMessage("Order ID cannot be an empty GUID.");
    }
}

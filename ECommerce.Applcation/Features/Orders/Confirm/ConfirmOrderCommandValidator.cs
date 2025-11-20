namespace ECommerce.Application.Features.Orders.Confirm;

public class ConfirmOrderCommandValidator : AbstractValidator<ConfirmOrderCommand>
{
    public ConfirmOrderCommandValidator()
    {
        RuleFor(x => x.OrderId)
            .NotEmpty().WithMessage("OrderId is required.")
            .NotEqual(Guid.Empty).WithMessage("OrderId is required.");
    }
}
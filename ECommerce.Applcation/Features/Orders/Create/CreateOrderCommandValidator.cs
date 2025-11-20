namespace ECommerce.Application.Features.Orders.Create;

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(x => x.CustomerId)
            .NotNull().WithMessage("Customer id can not be null.")
            .NotEmpty().WithMessage("Customer id can not be empty.");

        RuleFor(x => x.IdempotancyKey)
            .NotNull().WithMessage("Idempotancy Key can not be null.")
            .NotEmpty().WithMessage("Idempotancy Key can not be empty.");

        RuleFor(x => x.Items)
                .NotNull().WithMessage("Order items cannot be null.")
                .NotEmpty().WithMessage("Order must contain at least one item.");

        RuleForEach(x => x.Items)
            .SetValidator(new CreateOrderItemDtoValidator());
    }
}
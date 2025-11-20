using ECommerce.Application.Dtos.OrderItems;

namespace ECommerce.Application.Features.Orders.Create;

public class CreateOrderItemDtoValidator : AbstractValidator<CreateOrderItemDto>
{
    public CreateOrderItemDtoValidator()
    {
        RuleFor(x => x.ProductId)
            .NotNull().WithMessage("Product id can not be null.")
            .NotEmpty().WithMessage("Product id can not be empty.");

        RuleFor(x => x.Quantity)
            .GreaterThanOrEqualTo(1).WithMessage("Product quantity must be grater than 0.");

    }
}
namespace ECommerce.Application.Features.Orders.GetById;

public class GetOrderByIdQueryValidator : AbstractValidator<GetOrderByIdQuery>
{
    public GetOrderByIdQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Order Id is required.");
    }
}
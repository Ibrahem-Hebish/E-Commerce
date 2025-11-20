namespace ECommerce.Application.Features.Orders.GetByCustomerId;

public class GetOrdersByCastomerIdQueryValidator : AbstractValidator<GetOrdersByCastomerIdQuery>
{
    public GetOrdersByCastomerIdQueryValidator()
    {
        RuleFor(x => x.CustomerId).NotEmpty().WithMessage("CustomerId is required.");
    }
}
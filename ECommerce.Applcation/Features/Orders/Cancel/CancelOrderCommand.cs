namespace ECommerce.Application.Features.Orders.Cancel;

public record CancelOrderCommand(Guid OrderId) : IRequest<Response<string>>, IValidatorRequest, IReseatCache
{
    public string GroupCacheKey { get; private set; } = "Products";
}

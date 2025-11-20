using ECommerce.Application.Dtos.OrderItems;

namespace ECommerce.Application.Features.Orders.Create;

public record CreateOrderCommand : IRequest<Response<string>>, IValidatorRequest, IReseatCache
{
    public Guid CustomerId { get; set; }
    public List<CreateOrderItemDto> Items { get; set; }
    public Guid IdempotancyKey { get; set; }

    public string GroupCacheKey { get; private set; } = "Products";
}

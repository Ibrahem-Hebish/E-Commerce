using ECommerce.Application.Dtos.Products;

namespace ECommerce.Application.Features.Products.GetById;

public record GetProductByIdQuery(Guid Id) : IRequest<Response<GetProductDto>>, ICachedQuery
{
    public string CacheKey { get; private set; } = $"Products-{Id}";
    public string GroupCacheKey { get; private set; } = "Products";
    public TimeSpan? Expiration { get; set; } = TimeSpan.FromMinutes(1);
}

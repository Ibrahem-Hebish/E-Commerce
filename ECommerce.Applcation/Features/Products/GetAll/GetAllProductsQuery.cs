using ECommerce.Application.Dtos.Products;

namespace ECommerce.Application.Features.Products.GetAll;

public record GetAllProductsQuery : IRequest<Response<List<GetProductDto>>>, ICachedQuery
{
    public string CacheKey { get; set; } = "Products";
    public string GroupCacheKey { get; set; } = "Products";
    public TimeSpan? Expiration { get; set; } = TimeSpan.FromMinutes(2);
}


namespace ECommerce.Application.Features.Products.Update;

public record UpdateProductCommand : IRequest<Response<GetProductDto>>, IValidatorRequest, IReseatCache
{
    public string GroupCacheKey { get; private set; } = "Products";
    public Guid Id { get; set; }
    public string? Name { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public decimal? Price { get; set; }
    public int? StockQuantity { get; set; }
}

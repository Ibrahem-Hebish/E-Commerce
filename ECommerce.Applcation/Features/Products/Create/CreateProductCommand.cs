using ECommerce.Application.Dtos.Products;

namespace ECommerce.Application.Features.Products.Create;

public class CreateProductCommand : IRequest<Response<GetProductDto>>, IValidatorRequest, IReseatCache
{
    public string GroupCacheKey { get; private set; } = "Products";
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public bool HasDiscount { get; set; }
    public int DiscountPercentage { get; set; }
    public Guid? CategoryId { get; set; }
}

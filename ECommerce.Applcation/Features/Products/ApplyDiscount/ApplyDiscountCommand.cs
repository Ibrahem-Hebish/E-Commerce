
namespace ECommerce.Application.Features.Products.ApplyDiscount;

public record ApplyDiscountCommand(Guid ProductId, int DiscountPercentage) : IRequest<Response<GetProductDto>>, IValidatorRequest, IReseatCache
{
    public string GroupCacheKey { get; private set; } = "Products";
}

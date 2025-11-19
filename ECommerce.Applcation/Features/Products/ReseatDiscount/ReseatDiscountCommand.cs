namespace ECommerce.Application.Features.Products.ReseatDiscount;

public record ReseatDiscountCommand(Guid Id) : IRequest<Response<GetProductDto>>, IValidatorRequest, IReseatCache
{
    public string GroupCacheKey { get; private set; } = "Products";
}

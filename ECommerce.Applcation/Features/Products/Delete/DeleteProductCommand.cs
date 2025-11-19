namespace ECommerce.Application.Features.Products.Delete;

public record DeleteProductCommand(Guid Id) : IRequest<Response<string>>, IValidatorRequest, IReseatCache
{
    public string GroupCacheKey { get; private set; } = "Products";

}

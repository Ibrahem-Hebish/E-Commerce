
namespace ECommerce.Application.Features.Categories.Delete;

public record DeleteCategoryCommand(Guid Id) : IRequest<Response<string>>, IValidatorRequest, IReseatCache
{
    public string GroupCacheKey { get; private set; } = "Categories";
}

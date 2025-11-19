using ECommerce.Application.Dtos.Categories;

namespace ECommerce.Application.Features.Categories.Create;

public record CreateCategoryCommand(string Name, string Description) : IRequest<Response<GetCategoryDto>>, IValidatorRequest, IReseatCache
{
    public string GroupCacheKey { get; private set; } = "Categories";
}

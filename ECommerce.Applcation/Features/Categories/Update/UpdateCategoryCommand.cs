using ECommerce.Application.Dtos.Categories;

namespace ECommerce.Application.Features.Categories.Update;

public record UpdateCategoryCommand(Guid Id, UpdateCategoryDto Dto)
    : IRequest<Response<GetCategoryDto>>, IValidatorRequest, IReseatCache
{
    public string GroupCacheKey { get; private set; } = "Categories";
}

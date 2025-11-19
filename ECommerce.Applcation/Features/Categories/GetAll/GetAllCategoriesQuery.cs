using ECommerce.Application.Dtos.Categories;

namespace ECommerce.Application.Features.Categories.GetAll;

public record GetAllCategoriesQuery : IRequest<Response<List<GetCategoryDto>>>, ICachedQuery
{
    public string CacheKey { get; private set; } = "Categories";
    public TimeSpan? Expiration { get; private set; } = TimeSpan.FromMinutes(1);
    public string GroupCacheKey { get; private set; } = "Categories";
}

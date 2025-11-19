using ECommerce.Application.Dtos.Categories;

namespace ECommerce.Application.Features.Categories.GetAll;

public class GetAllCategoriesQueryHandler(
    ICategoryQueryRepository categoryQueryRepository,
    IMapper mapper)

    : ResponseHandler,
    IRequestHandler<GetAllCategoriesQuery, Response<List<GetCategoryDto>>>
{
    public async Task<Response<List<GetCategoryDto>>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await categoryQueryRepository.GetAllAsync();

        if(categories is null || categories.Count == 0)
            return NotFound<List<GetCategoryDto>>();

        var dtos = mapper.Map<List<GetCategoryDto>>(categories);

        return Success(dtos);
    }
}

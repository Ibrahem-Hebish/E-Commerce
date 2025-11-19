using ECommerce.Application.Dtos.Categories;

namespace ECommerce.Application.Features.Categories.GetById;

public class GetCategoryByIdQueryHandler(
    ICategoryQueryRepository categoryQueryRepository,
    IMapper mapper)

    : ResponseHandler,
    IRequestHandler<GetCategoryByIdQuery, Response<GetCategoryDto>>
{
    public async Task<Response<GetCategoryDto>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var category = await categoryQueryRepository.GetByIdAsync(request.Id);

        if(category is null)
            return NotFound<GetCategoryDto>();

        var dto = mapper.Map<GetCategoryDto>(category);

        return Success(dto);
    }
}

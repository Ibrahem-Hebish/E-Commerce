using ECommerce.Application.Dtos.Categories;

namespace ECommerce.Application.Features.Categories.Create;

public class CreateCategoryCommandHandler(
    ICategoryCommandRepository categoryCommandRepository,
    ICategoryQueryRepository categoryQueryRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper)

    : ResponseHandler,
    IRequestHandler<CreateCategoryCommand, Response<GetCategoryDto>>
{
    public async Task<Response<GetCategoryDto>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        bool exsisting = await categoryQueryRepository.ExistsByNameAsync(request.Name);

        if (exsisting)
            return BadRequest<GetCategoryDto>("There is category with the same name.");

        var category = mapper.Map<Category>(request);

        await categoryCommandRepository.AddAsync(category);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        var dto = mapper.Map<GetCategoryDto>(category);

        return Created(dto);
    }
}

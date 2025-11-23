using ECommerce.Application.Dtos.Categories;

namespace ECommerce.Application.Features.Categories.Update;

public class UpdateCategoryCommandHandler(
    ICategoryQueryRepository categoryQueryRepository,
    IMapper mapper,
    IUnitOfWork unitOfWork)
    : ResponseHandler,
    IRequestHandler<UpdateCategoryCommand, Response<GetCategoryDto>>
{
    public async Task<Response<GetCategoryDto>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var category = await categoryQueryRepository.GetByIdAsync(request.Id);

            if (category is null)
                return NotFound<GetCategoryDto>();

            if (request.Dto.Name is not null)
            {
                bool exsisting = await categoryQueryRepository.ExistsByNameAsync(request.Dto.Name);

                if (exsisting)
                    return BadRequest<GetCategoryDto>("There is category with the same name.");
            }

            category.Update(request.Dto.Name, request.Dto.Description);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            var dto = mapper.Map<GetCategoryDto>(category);

            return Success(dto);

        }
        catch (Exception ex)
        {
            Log.Error("Error while updating category with id {id}.Full exception : {ex}", request.Id, ex);

            return InternalServerError<GetCategoryDto>("Try again later.");
        }
    }
}
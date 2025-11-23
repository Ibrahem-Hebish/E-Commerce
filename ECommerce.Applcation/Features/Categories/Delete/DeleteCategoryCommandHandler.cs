
namespace ECommerce.Application.Features.Categories.Delete;

public class DeleteCategoryCommandHandler(
    ICategoryQueryRepository categoryQueryRepository,
    ICategoryCommandRepository categoryCommandRepository,
    IUnitOfWork unitOfWork)

    : ResponseHandler,
    IRequestHandler<DeleteCategoryCommand, Response<string>>
{
    public async Task<Response<string>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var category = await categoryQueryRepository.GetByIdAsync(request.Id);

            if (category is null)
                return NotFound<string>();

            var hasProducts = await categoryQueryRepository.HasProducts(request.Id);

            if (hasProducts)
                return BadRequest<string>("Can not delete categry that has products.");

            categoryCommandRepository.Delete(category);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Deleted<string>();

        }
        catch (Exception ex)
        {
            Log.Error("Error while deleteing category with id {id}.Full exception : {ex}", request.Id, ex);

            return InternalServerError<string>("Try again later.");
        }
    }
}

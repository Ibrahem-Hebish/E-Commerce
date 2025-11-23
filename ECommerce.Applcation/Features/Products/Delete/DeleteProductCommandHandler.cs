namespace ECommerce.Application.Features.Products.Delete;

public class DeleteProductCommandHandler(
    IProductQueryRepository productQueryRepository,
    IProductCommandRepository productCommandRepository,
    IUnitOfWork unitOfWork)

    : ResponseHandler,
    IRequestHandler<DeleteProductCommand, Response<string>>
{
    public async Task<Response<string>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var product = await productQueryRepository.GetByIdAsync(request.Id);

            if (product is null)
                return NotFound<string>("Product not found");

            productCommandRepository.Delete(product);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Deleted<string>("Product deleted successfully");
        }
        catch (Exception ex)
        {
            Log.Error("Error occurred while deleting product with id {id}.Full exception", request.Id, ex);

            return InternalServerError<string>();
        }
    }
}
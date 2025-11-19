
namespace ECommerce.Application.Features.Products.Update;

public class UpdateProductCommandHandler(
    IProductQueryRepository productQueryRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper)

    : ResponseHandler,
    IRequestHandler<UpdateProductCommand, Response<GetProductDto>>
{
    public async Task<Response<GetProductDto>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await productQueryRepository.GetByIdAsync(request.Id);

        if (product is null)
            return NotFound<GetProductDto>();

        if(request.Name is not null)
        {
            var exsistedName = await productQueryRepository.GetByCategoryIdAndName(product.CategoryId, request.Name);

            if(exsistedName is not null)
                return BadRequest<GetProductDto>("You can not use this name as it is exsisted in the same category");
        }

        product.Update(request.Name, request.Description, request.Price, request.StockQuantity);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        var dto = mapper.Map<GetProductDto>(product);

        return Success(dto);

    }
}

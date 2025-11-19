
namespace ECommerce.Application.Features.Products.ApplyDiscount;

public class ApplyDiscountCommandHandler(
    IProductQueryRepository productQueryRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper)

    : ResponseHandler,
    IRequestHandler<ApplyDiscountCommand, Response<GetProductDto>>
{
    public async Task<Response<GetProductDto>> Handle(ApplyDiscountCommand request, CancellationToken cancellationToken)
    {
        var product = await productQueryRepository.GetByIdAsync(request.ProductId);

        if (product is null)
            return NotFound<GetProductDto>();

        product.ApplyDiscount(request.DiscountPercentage);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        var dto = mapper.Map<GetProductDto>(product);

        return Success(dto);
    }
}

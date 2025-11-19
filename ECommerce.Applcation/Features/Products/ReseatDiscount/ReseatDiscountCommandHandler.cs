namespace ECommerce.Application.Features.Products.ReseatDiscount;

public class ReseatDiscountCommandHandler(
    IProductQueryRepository productQueryRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper)

    : ResponseHandler,
    IRequestHandler<ReseatDiscountCommand, Response<GetProductDto>>
{
    public async Task<Response<GetProductDto>> Handle(ReseatDiscountCommand request, CancellationToken cancellationToken)
    {
        var product = await productQueryRepository.GetByIdAsync(request.Id);

        if (product is null)
            return NotFound<GetProductDto>();

        product.RemoveDiscount();

        await unitOfWork.SaveChangesAsync(cancellationToken);

        var dto = mapper.Map<GetProductDto>(product);

        return Success(dto);
    }
}
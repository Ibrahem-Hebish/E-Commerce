namespace ECommerce.Application.Features.Products.SortProducts;

public class SortProductsQueryHandler(
    IProductQueryRepository productQueryRepository,
    IMapper mapper)

    : ResponseHandler,
    IRequestHandler<SortProductsQuery, Response<List<GetProductDto>>>
{
    public async Task<Response<List<GetProductDto>>> Handle(SortProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await productQueryRepository.SortByAsync(request.SortBy, request.SortDirection);

        if (products.Count == 0)
            return NotFound<List<GetProductDto>>();

        var productsDto = mapper.Map<List<GetProductDto>>(products);

        return Success(productsDto);
    }
}
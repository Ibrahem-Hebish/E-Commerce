
namespace ECommerce.Application.Features.Products.Paginate;

public class PaginateProductsQueryHandler(
    IProductQueryRepository productQueryRepository,
    IMapper mapper)

    : ResponseHandler,
    IRequestHandler<PaginateProductsQuery, Response<List<GetProductDto>>>
{
    public async Task<Response<List<GetProductDto>>> Handle(PaginateProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await productQueryRepository.Paginate(request.LastCreatedAt, request.PageSize, request.PaginationDirection);

        if (products is null || products.Count == 0)
            return NotFound<List<GetProductDto>>();

        var dtos = mapper.Map<List<GetProductDto>>(products);

        return Success(dtos);
    }
}

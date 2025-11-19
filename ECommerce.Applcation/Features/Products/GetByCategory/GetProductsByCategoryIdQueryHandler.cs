using ECommerce.Application.Dtos.Products;
using ECommerce.Domain.Repositories.Products;

namespace ECommerce.Application.Features.Products.GetByCategory;

public class GetProductsByCategoryIdQueryHandler(
    IProductQueryRepository productQueryRepository,
    IMapper mapper)

    : ResponseHandler,
    IRequestHandler<GetProductsByCategoryIdQuery, Response<List<GetProductDto>>>
{
    public async Task<Response<List<GetProductDto>>> Handle(GetProductsByCategoryIdQuery request, CancellationToken cancellationToken)
    {
        var products = await productQueryRepository.GetByCategoryIdAsync(request.Id);

        if (products is null || products.Count == 0)
            return NotFound<List<GetProductDto>>();

        var dtos = mapper.Map<List<GetProductDto>>(products);

        return Success(dtos);
    }
}

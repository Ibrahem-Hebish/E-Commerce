using ECommerce.Application.Dtos.Products;
using ECommerce.Domain.Repositories.Products;

namespace ECommerce.Application.Features.Products.SearchByName;

public class SearchProductsByNameQueryHandler(
    IProductQueryRepository productQueryRepository,
    IMapper mapper)

    : ResponseHandler,
    IRequestHandler<SearchProductsByNameQuery, Response<List<GetProductDto>>>
{
    public async Task<Response<List<GetProductDto>>> Handle(SearchProductsByNameQuery request, CancellationToken cancellationToken)
    {
        var products = await productQueryRepository.SearchByNameAsync(request.Name);

        if (products is null || products.Count == 0)
            return NotFound<List<GetProductDto>>();

        var dtos = mapper.Map<List<GetProductDto>>(products);

        return Success(dtos);
    }
}

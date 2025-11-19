using ECommerce.Application.Dtos.Products;
using ECommerce.Domain.Repositories.Products;

namespace ECommerce.Application.Features.Products.GetAll;

public class GetAllProductsQueryHandler(
    IProductQueryRepository productQueryRepository,
    IMapper mapper)

    : ResponseHandler,
    IRequestHandler<GetAllProductsQuery, Response<List<GetProductDto>>>
{
    public async Task<Response<List<GetProductDto>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await productQueryRepository.GetAllAsync();

        if(products is null ||  products.Count == 0)
            return NotFound<List<GetProductDto>>();

        var dtos = mapper.Map<List<GetProductDto>>(products);

        return Success(dtos);
    }
}

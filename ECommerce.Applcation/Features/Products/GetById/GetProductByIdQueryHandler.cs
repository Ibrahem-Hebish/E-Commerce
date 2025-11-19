using ECommerce.Application.Dtos.Products;
using ECommerce.Domain.Repositories.Products;

namespace ECommerce.Application.Features.Products.GetById;

public class GetProductByIdQueryHandler(
    IProductQueryRepository productQueryRepository,
    IMapper mapper)

    : ResponseHandler,
    IRequestHandler<GetProductByIdQuery, Response<GetProductDto>>
{
    public async Task<Response<GetProductDto>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await productQueryRepository.GetByIdAsync(request.Id);

        if(product is null)
            return NotFound<GetProductDto>();

        var dto = mapper.Map<GetProductDto>(product);

        return Success(dto);
    }
}

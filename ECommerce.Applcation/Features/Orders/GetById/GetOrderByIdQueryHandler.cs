using ECommerce.Application.Dtos.Orders;
using ECommerce.Domain.Repositories.Orders;

namespace ECommerce.Application.Features.Orders.GetById;

public class GetOrderByIdQueryHandler(
    IOrderQueryRepository orderQueryRepository,
    IMapper mapper)

    : ResponseHandler,
    IRequestHandler<GetOrderByIdQuery, Response<GetOrderDto>>
{
    public async Task<Response<GetOrderDto>> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var order = await orderQueryRepository.GetByIdAsync(request.Id);

        if (order is null)
            return NotFound<GetOrderDto>();

        var dto = mapper.Map<GetOrderDto>(order);

        return Success(dto);
    }
}

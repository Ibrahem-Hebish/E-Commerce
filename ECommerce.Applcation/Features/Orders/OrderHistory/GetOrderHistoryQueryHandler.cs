using ECommerce.Application.Dtos.OrderTracks;
using ECommerce.Domain.Repositories.Orders;
using ECommerce.Domain.Repositories.OrderTracks;
using System.Security.Claims;

namespace ECommerce.Application.Features.Orders.OrderHistory;

public class GetOrderHistoryQueryHandler(
    IOrderQueryRepository orderQueryRepository,
    IHttpContextAccessor httpContextAccessor,
    IOrderTrackQueryRepository orderTrackQueryRepository,
    IMapper mapper)

    : ResponseHandler,
    IRequestHandler<GetOrderHistoryQuery, Response<List<GetOrderTrackDto>>>
{
    public async Task<Response<List<GetOrderTrackDto>>> Handle(GetOrderHistoryQuery request, CancellationToken cancellationToken)
    {
        var context = httpContextAccessor.HttpContext!;
        var userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);
        var role = context.User.FindFirstValue(ClaimTypes.Role);

        var order = await orderQueryRepository.GetByIdAsync(request.OrderId);

        if (order is null)
            return NotFound<List<GetOrderTrackDto>>("Order not found.");

        if (role != "Admin" && order.CustomerId != Guid.Parse(userId!))
            return UnAuthorize<List<GetOrderTrackDto>>("You are not authorized to view this order history.");

        var orderTracks = await orderTrackQueryRepository.GetByOrderIdAsync(request.OrderId);

        var orderTracksDto = mapper.Map<List<GetOrderTrackDto>>(orderTracks);

        return Success(data: orderTracksDto,
                      message: "Order history retrieved successfully.");
    }
}
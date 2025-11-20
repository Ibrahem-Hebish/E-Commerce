using ECommerce.Application.Dtos.OrderTracks;

namespace ECommerce.Application.Features.Orders.OrderHistory;

public record GetOrderHistoryQuery(Guid OrderId) : IRequest<Response<List<GetOrderTrackDto>>>, IValidatorRequest;

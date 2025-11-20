using ECommerce.Application.Dtos.Orders;

namespace ECommerce.Application.Features.Orders.GetAll;

public record GetAllOrdersQuery : IRequest<Response<List<GetOrderDto>>>;



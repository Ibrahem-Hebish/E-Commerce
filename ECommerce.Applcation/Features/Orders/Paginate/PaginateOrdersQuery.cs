using ECommerce.Application.Dtos.Orders;

namespace ECommerce.Application.Features.Orders.Paginate;

public record PaginateOrdersQuery(DateTime? LastCreatedAt, int? PageSize, PaginationDirection PaginationDirection)
    : IRequest<Response<List<GetOrderDto>>>, IValidatorRequest;

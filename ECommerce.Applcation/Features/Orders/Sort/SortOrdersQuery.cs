namespace ECommerce.Application.Features.Orders.Sort;

public record SortOrdersQuery(
    SortOrdersBy SortBy,
    SortDirection Direction) : IRequest<Response<List<Order>>>, IValidatorRequest;

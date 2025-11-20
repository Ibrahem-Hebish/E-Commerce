
namespace ECommerce.Application.Features.Products.Paginate;

public record PaginateProductsQuery(DateTime? LastCreatedAt, int? PageSize, PaginationDirection PaginationDirection)
    : IRequest<Response<List<GetProductDto>>>, IValidatorRequest;

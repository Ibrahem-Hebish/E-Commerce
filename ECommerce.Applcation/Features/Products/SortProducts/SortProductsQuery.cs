namespace ECommerce.Application.Features.Products.SortProducts;

public record SortProductsQuery(SortProductBy SortBy, SortDirection SortDirection) : IRequest<Response<List<GetProductDto>>>, IValidatorRequest
{
}

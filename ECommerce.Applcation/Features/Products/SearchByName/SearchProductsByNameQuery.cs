using ECommerce.Application.Dtos.Products;

namespace ECommerce.Application.Features.Products.SearchByName;

public record SearchProductsByNameQuery(string Name) : IRequest<Response<List<GetProductDto>>>;

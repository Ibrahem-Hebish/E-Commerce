using ECommerce.Application.Dtos.Products;

namespace ECommerce.Application.Features.Products.GetByCategory;

public record GetProductsByCategoryIdQuery(Guid Id) : IRequest<Response<List<GetProductDto>>>;

using ECommerce.Application.Dtos.Categories;

namespace ECommerce.Application.Features.Categories.GetById;

public record GetCategoryByIdQuery(Guid Id) : IRequest<Response<GetCategoryDto>>;

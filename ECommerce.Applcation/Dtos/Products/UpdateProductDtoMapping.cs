using ECommerce.Application.Features.Products.Update;

namespace ECommerce.Application.Dtos.Products;

public class UpdateProductDtoMapping : Profile
{
    public UpdateProductDtoMapping()
    {
        CreateMap<UpdateProductDto, UpdateProductCommand>();
    }
}
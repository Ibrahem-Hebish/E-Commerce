namespace ECommerce.Application.Dtos.Products;

public class GetProductDtoMapping : Profile
{
    public GetProductDtoMapping()
    {
        CreateMap<Product, GetProductDto>();
    }
}
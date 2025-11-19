namespace ECommerce.Application.Features.Products.Create;

public class CreateProductMapping : Profile
{
    public CreateProductMapping()
    {
        CreateMap<CreateProductCommand, Product>();
    }
}


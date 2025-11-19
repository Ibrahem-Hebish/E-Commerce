namespace ECommerce.Application.Features.Categories.Create;

public class CreateCategoryMapping : Profile
{
    public CreateCategoryMapping()
    {
        CreateMap<CreateCategoryCommand, Category>();
    }
}

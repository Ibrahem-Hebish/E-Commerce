namespace ECommerce.Application.Dtos.Categories;

public class GetCategoryDtoMapping : Profile
{
    public GetCategoryDtoMapping()
    {
        CreateMap<Category, GetCategoryDto>();
    }
}
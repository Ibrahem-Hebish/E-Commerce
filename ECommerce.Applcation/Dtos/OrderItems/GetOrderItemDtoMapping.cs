namespace ECommerce.Application.Dtos.OrderItems;

public class GetOrderItemDtoMapping : Profile
{
    public GetOrderItemDtoMapping()
    {
        CreateMap<OrderItem, GetOrderItemDto>()
            .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product!.Name));
    }
}

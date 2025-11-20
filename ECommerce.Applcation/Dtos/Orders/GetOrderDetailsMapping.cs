namespace ECommerce.Application.Dtos.Orders;

public class GetOrderDetailsMapping : Profile
{
    public GetOrderDetailsMapping()
    {
        CreateMap<Order, GetOrderDetails>()
            .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.Customer))
            .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.OrderItems));
    }
}
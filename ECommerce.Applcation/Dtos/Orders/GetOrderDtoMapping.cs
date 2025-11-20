namespace ECommerce.Application.Dtos.Orders;

public class GetOrderDtoMapping : Profile
{
    public GetOrderDtoMapping()
    {
        CreateMap<Order, GetOrderDto>()
            .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.Customer));
    }
}
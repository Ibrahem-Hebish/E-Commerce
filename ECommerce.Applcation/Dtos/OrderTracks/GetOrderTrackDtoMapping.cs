namespace ECommerce.Application.Dtos.OrderTracks;

public class GetOrderTrackDtoMapping : Profile
{
    public GetOrderTrackDtoMapping()
    {
        CreateMap<OrderTrack, GetOrderTrackDto>()
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));
    }
}
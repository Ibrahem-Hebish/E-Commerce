namespace ECommerce.Domain.Repositories.OrderTracks;

public interface IOrderTrackCommandRepository
{
    Task AddAsync(OrderTrack orderTrack);
}

namespace ECommerce.Domain.Repositories.OrderTracks;

public interface IOrderTrackQueryRepository
{
    Task<List<OrderTrack>> GetByOrderIdAsync(Guid id);
}
using ECommerce.Domain.Repositories.OrderTracks;

namespace ECommerce.Infrustructure.Persistance.Repositories.OrderTracks;

public class OrderTrackCommandRepository(AppDbContext dbContext) : IOrderTrackCommandRepository
{
    public async Task AddAsync(OrderTrack orderTrack) => await dbContext.OrderTracks.AddAsync(orderTrack);
}

using ECommerce.Domain.Repositories.OrderTracks;

namespace ECommerce.Infrustructure.Persistance.Repositories.OrderTracks;

public class OrderTrackQueryRepository(AppDbContext dbContext) : IOrderTrackQueryRepository
{
    public async Task<List<OrderTrack>> GetByOrderIdAsync(Guid orderId) =>
        await dbContext.OrderTracks
            .Where(ot => ot.OrderId == orderId)
            .ToListAsync();
}
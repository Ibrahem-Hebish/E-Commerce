namespace ECommerce.Domain.Entities;

public class OrderTrack
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public OrderStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid OrderId { get; set; }
    public Order Order { get; set; }
}

namespace ECommerce.Domain.Entities;

public class OrderTrack
{
    public Guid Id { get; set; }
    public OrderStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid OrderId { get; set; }
    public virtual Order Order { get; set; }

    public OrderTrack()
    {

    }

    public OrderTrack(OrderStatus status, Guid orderId)
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
        Status = status;
        OrderId = orderId;

    }
}

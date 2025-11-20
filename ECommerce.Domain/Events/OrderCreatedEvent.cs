namespace ECommerce.Domain.Events;

public class OrderCreatedEvent(string email, Guid orderId) : DomainEvent
{
    public string Email { get; } = email;
    public Guid OrderId { get; } = orderId;
}

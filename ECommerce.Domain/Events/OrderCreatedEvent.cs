namespace ECommerce.Domain.Events;

public class OrderCreatedEvent(string email, string message, Order order) : DomainEvent
{
}

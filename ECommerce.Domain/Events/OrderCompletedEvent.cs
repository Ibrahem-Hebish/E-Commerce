namespace ECommerce.Domain.Events;

public class OrderCompletedEvent(string email, string message, Order order) : DomainEvent
{

}

namespace ECommerce.Domain.Events;

public class OrderCanceledEvent(string email, string message, Order order) : DomainEvent
{

}

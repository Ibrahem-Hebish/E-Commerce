namespace ECommerce.Domain.Events;

public class CustomerRegisteredEvent(string email, string message, User customer) : DomainEvent
{
}
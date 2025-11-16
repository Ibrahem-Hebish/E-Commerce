namespace ECommerce.Domain.Events;

public class CustomerRegisteredEvent(string email, string message, User customer) : DomainEvent
{
    public string Email { get; } = email;
    public string Message { get; } = message;
    public User Customer { get; } = customer;
}
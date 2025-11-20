using ECommerce.Domain.Common;

namespace ECommerce.Domain.Entities;

public class Order : Entity
{
    public Guid Id { get; private set; }
    public DateTime OrderDate { get; private set; }
    public DateTime? UpdatedAt { get; set; }
    public decimal TotalAmount { get; set; }
    public OrderStatus Status { get; private set; }
    public Guid IdempotencyKey { get; set; }
    public Guid CustomerId { get; set; }
    public virtual User Customer { get; set; }
    public virtual List<OrderItem> OrderItems { get; set; } = [];
    public virtual List<OrderTrack> OrderTracks { get; set; } = [];

    public Order() { }
    public Order(User customer, List<OrderItem> items, Guid idempotancyKey)
    {
        Id = Guid.NewGuid();
        OrderDate = DateTime.UtcNow;
        Status = OrderStatus.Pending;
        CustomerId = customer.Id;
        OrderItems = items;
        IdempotencyKey = idempotancyKey;

        DomainEvents.Add(new OrderCreatedEvent(customer.Email, Id));

        CalculateTotalAmount();
    }


    public void Confirm()
    {
        if (Status != OrderStatus.Pending)
            throw new InvalidOperationException("Only pending orders can be confirmed.");

        Status = OrderStatus.Completed;

        UpdatedAt = DateTime.UtcNow;

        DomainEvents.Add(new OrderCompletedEvent(Customer.Email, Id));
    }
    public void Cancel()
    {
        if (Status != OrderStatus.Pending)
            throw new InvalidOperationException("Only pending orders can be canceled.");

        Status = OrderStatus.Canceled;

        UpdatedAt = DateTime.UtcNow;

        DomainEvents.Add(new OrderCanceledEvent(Customer.Email, Id));
    }
    public void CalculateTotalAmount()
    {
        TotalAmount = OrderItems.Sum(item => item.UnitPrice * item.Quantity);
    }
    public void SetCustomer(User customer)
    {
        Customer = customer;
        CustomerId = customer.Id;
    }
}

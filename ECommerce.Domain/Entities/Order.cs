using ECommerce.Domain.Common;

namespace ECommerce.Domain.Entities;

public class Order : Entity
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public DateTime OrderDate { get; private set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    public decimal TotalAmount { get; set; }
    public OrderStatus Status { get; private set; } = OrderStatus.Pending;
    public Guid CustomerId { get; set; }
    public User Customer { get; set; }
    public List<OrderItem> OrderItems { get; set; } = [];
    public List<OrderTrack> OrderTracks { get; set; } = [];


    public void AddOrderItem(OrderItem item)
    {
        OrderItems.Add(item);
    }
    public void RemoveOrderItem(OrderItem item)
    {
        OrderItems.Remove(item);
    }
    public void AddOrderTrack(OrderTrack track)
    {
        OrderTracks.Add(track);
    }
    public void RemoveOrderTrack(OrderTrack track)
    {
        OrderTracks.Remove(track);
    }
    public void ConfirmOrder()
    {
        if (Status != OrderStatus.Pending)
            throw new InvalidOperationException("Only pending orders can be confirmed.");

        Status = OrderStatus.Completed;

        AddOrderTrack(new OrderTrack
        {
            Id = Guid.NewGuid(),
            Status = OrderStatus.Completed,
            CreatedAt = DateTime.UtcNow,
            OrderId = Id,
            Order = this
        });

        DomainEvents.Add(new OrderCompletedEvent(Customer.Email, "Your order completed successfully.", this));
    }
    public void CancelOrder()
    {
        if (Status != OrderStatus.Pending)
            throw new InvalidOperationException("Only pending orders can be canceled.");

        Status = OrderStatus.Canceled;
        AddOrderTrack(new OrderTrack
        {
            Id = Guid.NewGuid(),
            Status = OrderStatus.Canceled,
            CreatedAt = DateTime.UtcNow,
            OrderId = Id,
            Order = this
        });
        DomainEvents.Add(new OrderCanceledEvent(Customer.Email, "Your order has been canceled.", this));
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

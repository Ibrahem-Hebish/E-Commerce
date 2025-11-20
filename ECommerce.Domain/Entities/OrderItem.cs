namespace ECommerce.Domain.Entities;

public class OrderItem
{
    public Guid Id { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public Guid OrderId { get; set; }
    public virtual Order Order { get; set; }
    public Guid? ProductId { get; set; }
    public virtual Product? Product { get; set; }

    public OrderItem() { }
    public OrderItem(Guid productId, int quantity, decimal unitPrice)
    {
        Id = Guid.NewGuid();
        ProductId = productId;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }

}
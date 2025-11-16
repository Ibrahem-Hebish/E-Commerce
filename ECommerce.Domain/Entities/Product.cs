using ECommerce.Domain.SoftDeleting;

namespace ECommerce.Domain.Entities;

public class Product : ISoftDeletable
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public bool HasDiscount { get; set; }
    public int DiscountPercentage { get; set; }
    public decimal TotalPrice
    {
        get
        {
            if (!HasDiscount) return Price;

            return Price - (Price * DiscountPercentage / 100);
        }
    }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
    public Guid? CategoryId { get; set; }
    public Category? Category { get; set; }


    public void ApplyDiscount(int percentage)
    {
        if (percentage < 0 || percentage > 100)
        {
            throw new ArgumentOutOfRangeException(nameof(percentage), "Discount percentage must be between 0 and 100.");
        }
        HasDiscount = true;
        DiscountPercentage = percentage;
        UpdatedAt = DateTime.UtcNow;
    }
    public void RemoveDiscount()
    {
        HasDiscount = false;
        DiscountPercentage = 0;
        UpdatedAt = DateTime.UtcNow;
    }
    public void ChangePrice(decimal newPrice)
    {
        if (newPrice < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(newPrice), "Price cannot be negative.");
        }
        Price = newPrice;
        UpdatedAt = DateTime.UtcNow;
    }
    public void AddStock(int quantity)
    {
        if (quantity < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity to add cannot be negative.");
        }
        StockQuantity += quantity;
        UpdatedAt = DateTime.UtcNow;
    }
    public void ReduceStock(int quantity)
    {
        if (quantity < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity to reduce cannot be negative.");
        }
        if (quantity > StockQuantity)
        {
            throw new InvalidOperationException("Insufficient stock to reduce the requested quantity.");
        }
        StockQuantity -= quantity;
        UpdatedAt = DateTime.UtcNow;
    }
    public void SetCategory(Category category)
    {
        Category = category;
        CategoryId = category.Id;
        UpdatedAt = DateTime.UtcNow;
    }


}

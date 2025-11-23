using ECommerce.Domain.Common;
using ECommerce.Domain.Common.SoftDeleting;

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

    public decimal TotalPrice { get; private set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
    public byte[] RowVersion { get; set; }
    public Guid? CategoryId { get; set; }
    public virtual Category? Category { get; set; }


    public void ApplyDiscount(int percentage)
    {
        if (percentage < 0 || percentage > 100)
        {
            throw new DomainException("Discount percentage must be between 0 and 100.");
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
            throw new DomainException("Price cannot be negative.");
        }

        Price = newPrice;
        UpdatedAt = DateTime.UtcNow;
    }
    public void AddStock(int quantity)
    {
        if (quantity < 0)
        {
            throw new DomainException("Quantity to add cannot be negative.");
        }
        StockQuantity += quantity;
        UpdatedAt = DateTime.UtcNow;
    }
    public void ReduceStock(int quantity)
    {
        if (quantity < 0)
        {
            throw new DomainException("Quantity to reduce cannot be negative.");
        }
        if (quantity > StockQuantity)
        {
            throw new DomainException("Insufficient stock to reduce the requested quantity.");
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
    public void Update(string? name, string? description, decimal? price, int? qunatity)
    {
        if (name is not null)
            Name = name;

        if (description is not null)
            Description = description;

        if (price is not null)
            Price = price.Value;

        if (qunatity is not null)
            StockQuantity = qunatity.Value;
    }


}

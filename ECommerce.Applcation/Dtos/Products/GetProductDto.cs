namespace ECommerce.Application.Dtos.Products;

public class GetProductDto
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public bool HasDiscount { get; set; }
    public int DiscountPercentage { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime CreatedAt { get; set; }
}

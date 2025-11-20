namespace ECommerce.Domain.Entities;

public class Category
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    public virtual List<Product> Products { get; set; }


    public void Update(string? name, string? description)
    {
        if (!string.IsNullOrWhiteSpace(name))
        {
            Name = name;

            UpdatedAt = DateTime.UtcNow;
        }
        if (!string.IsNullOrWhiteSpace(description))
        {
            Description = description;

            UpdatedAt = DateTime.UtcNow;
        }

    }
}
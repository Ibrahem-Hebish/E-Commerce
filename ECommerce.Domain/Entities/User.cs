using ECommerce.Domain.Common;
using ECommerce.Domain.SoftDeleting;

namespace ECommerce.Domain.Entities;

public class User : Entity, ISoftDeletable
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string PasswordHash { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }
    public Guid RoleId { get; set; }
    public Role Role { get; set; }
    public List<Order> Orders { get; set; } = [];
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }

    public void AssignRole(Role role)
    {
        Role = role;
        RoleId = role.Id;
    }

    public void NewCustomerRegistered()
    {
        DomainEvents.Add(new CustomerRegisteredEvent(Email, "Welcome to our e-commerce platform!", this));
    }
}

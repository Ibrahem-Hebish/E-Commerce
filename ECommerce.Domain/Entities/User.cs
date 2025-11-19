using ECommerce.Domain.Common;
using ECommerce.Domain.Common.SoftDeleting;

namespace ECommerce.Domain.Entities;

public class User : Entity, ISoftDeletable
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }
    public Guid RoleId { get; set; }
    public Role Role { get; set; }
    public List<Order> Orders { get; set; } = [];
    public List<UserToken> UserTokens { get; set; } = [];
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }

    public void AssignRole(Role role)
    {
        Role = role;
        RoleId = role.Id;
    }

    public void Update(string? name, string? phone)
    {
        if (!String.IsNullOrWhiteSpace(name))
            Name = name;

        if (!String.IsNullOrWhiteSpace(phone))
            PhoneNumber = phone;
    }

    public void SetPassword(string passwordHash)
    {
        PasswordHash = passwordHash;
    }

    public void NewCustomerRegistered()
    {
        DomainEvents.Add(new CustomerRegisteredEvent(Email, "Welcome to our e-commerce platform!", this));
    }

    public bool Activate()
    {
        if (!IsDeleted)
            return false;

        IsDeleted = false;
        DeletedAt = null;

        return true;
    }
}

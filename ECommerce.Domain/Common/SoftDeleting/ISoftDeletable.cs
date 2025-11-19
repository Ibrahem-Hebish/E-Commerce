namespace ECommerce.Domain.Common.SoftDeleting;

public interface ISoftDeletable
{
    bool IsDeleted { get; set; }

    DateTime? DeletedAt { get; set; }

    void Delete()
    {
        IsDeleted = true;
        DeletedAt = DateTime.UtcNow;
    }

    void Restore()
    {
        IsDeleted = false;
        DeletedAt = null;
    }
}


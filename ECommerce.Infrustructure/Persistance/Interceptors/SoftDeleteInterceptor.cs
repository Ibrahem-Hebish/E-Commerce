namespace ECommerce.Infrustructure.Persistance.Interceptors;

public class SoftDeleteInterceptor : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        var context = eventData.Context;

        if (context is null)
            return result;

        foreach (var entry in context.ChangeTracker.Entries())
        {
            if (entry is null || entry.State != EntityState.Deleted || entry is not ISoftDeletable entity)
                continue;

            entry.State = EntityState.Modified;

            entity.Delete();
        }

        return result;
    }
}


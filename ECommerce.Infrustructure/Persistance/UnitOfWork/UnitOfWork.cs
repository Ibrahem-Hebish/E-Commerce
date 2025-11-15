namespace ECommerce.Infrustructure.Persistance.UnitOfWork;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    public async Task SaveChangesAsync(CancellationToken cancellationToken)
       => await context.SaveChangesAsync(cancellationToken);

    public async Task BeginTransactionAsync()
        => await context.Database.BeginTransactionAsync();


    public async Task CommitTransactionAsync()
       => await context.Database.CommitTransactionAsync();

    public async Task RollbackTransactionAsync()
       => await context.Database.RollbackTransactionAsync();
}

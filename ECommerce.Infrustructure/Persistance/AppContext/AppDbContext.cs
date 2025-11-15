using ECommerce.Infrustructure.Persistance.Interceptors;

namespace ECommerce.Infrustructure.Persistance.AppContext;

public class AppDbContext : DbContext
{
    //private readonly IPublisher _publisher;
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<OrderItem> Items { get; set; }
    public DbSet<OrderTrack> OrderTracks { get; set; }

    public AppDbContext()
    {

    }
    public AppDbContext(DbContextOptions<AppDbContext> options/*, IPublisher publisher*/) : base(options)
    {
        //_publisher = publisher;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        var config = new ConfigurationBuilder()
            .AddJsonFile("json.json")
            .Build();

        var connectionString = config.GetSection("ConnectionString").Value;

        optionsBuilder.UseSqlServer(connectionString)
                        .AddInterceptors(new SoftDeleteInterceptor());
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {

        var domainEvents = ChangeTracker.Entries<Entity>()
            .Select(e => e.Entity)
            .Where(e => e.DomainEvents.Count != 0)
            .SelectMany(x => x.DomainEvents)
            .ToList();

        var result = await base.SaveChangesAsync(cancellationToken);

        foreach (var domainEvent in domainEvents)
        {
            //await _publisher.Publish(domainEvent, cancellationToken);
        }

        return result;
    }

}

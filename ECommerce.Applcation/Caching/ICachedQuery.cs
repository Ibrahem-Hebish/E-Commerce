namespace ECommerce.Application.Caching;

public interface ICachedQuery
{
    public string CacheKey { get; }
    public TimeSpan? Expiration { get; }
    public string GroupCacheKey { get; }
}

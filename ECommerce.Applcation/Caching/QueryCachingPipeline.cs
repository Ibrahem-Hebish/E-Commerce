using ECommerce.Application.GenericResponse;
using Microsoft.Extensions.Caching.Memory;

namespace ECommerce.Application.Caching;

public class QueryCachingPipeline<TRequest, TResponse>(
    IMemoryCache cache,
    ICacheGroups cacheGroups)

    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : ICachedQuery
    where TResponse : IResponse
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!cache.TryGetValue(request.CacheKey, out TResponse? response))
        {

            var result = await next(cancellationToken);

            if (result.IsSuccess)
            {
                cache.Set(request.CacheKey, result, new MemoryCacheEntryOptions
                {
                    SlidingExpiration = request.Expiration ?? TimeSpan.FromMinutes(5)
                });

                cacheGroups.AddToGroup(request.GroupCacheKey, request.CacheKey);

            }

            return result;
        }

        return response!;
    }
}


using ECommerce.Application.GenericResponse;
using Microsoft.Extensions.Caching.Memory;

namespace ECommerce.Application.Caching;

public class ReseatCachingPipeline<TRequest, TResponse>(IMemoryCache cache, ICacheGroups cacheGroups) :
    IPipelineBehavior<TRequest, TResponse>
    where TRequest : IReseatCache
    where TResponse : IResponse
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var result = await next(cancellationToken);

        if (result.IsSuccess)
        {
            var keys = cacheGroups.GetKeysByGroup(request.GroupCacheKey);

            foreach (var key in keys)
                cache.Remove(key);

            cache.Remove(request.GroupCacheKey);

            cacheGroups.RemoveGroup(request.GroupCacheKey);
        }


        return result;
    }
}

using System.Collections.Concurrent;

namespace ECommerce.Application.Caching;

public class CacheGroups : ICacheGroups
{
    private readonly ConcurrentDictionary<string, ConcurrentBag<string>> _groups
        = new();

    public void AddToGroup(string groupName, string key)
    {
        var group = _groups.GetOrAdd(groupName, _ => []);
        group.Add(key);
    }

    public List<string> GetKeysByGroup(string groupName)
    {
        return _groups.TryGetValue(groupName, out var group)
            ? [.. group]
            : [];
    }

    public void RemoveGroup(string groupName)
    {
        _groups.TryRemove(groupName, out _);
    }

}

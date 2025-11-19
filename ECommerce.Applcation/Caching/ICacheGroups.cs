namespace ECommerce.Application.Caching;

public interface ICacheGroups
{
    List<string> GetKeysByGroup(string groupName);
    void AddToGroup(string groupName, string key);
    void RemoveGroup(string groupName);
}

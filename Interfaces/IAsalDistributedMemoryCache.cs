using System.Threading.Tasks;

namespace Asal.DistributedCache.Interfaces
{
    public interface IAsalDistributedMemoryCache
    {
        T Get<T>(string key);
        Task<T> GetAsync<T>(string key);

        void Set(string key, object data, int cacheTimeInMinutes = 60);
        Task SetAsync(string key, object data, int cacheTimeInMinutes = 60);

        void Remove(string key);
        Task RemoveAsync(string key);

        bool IsExistedKey(string key);
        Task<bool> IsExistedKeyAsync(string key);
    }
}
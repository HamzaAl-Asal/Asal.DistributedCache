using Asal.DistributedCache.Options;
using System.Threading.Tasks;

namespace Asal.DistributedCache.Interfaces
{
    public interface IAsalDistributedMemoryCache
    {
        T Get<T>(string key);
        Task<T> GetAsync<T>(string key);

        void Set(string key, object data, AsalDistributedCacheOptions cacheOptions);
        Task SetAsync(string key, object data, AsalDistributedCacheOptions cacheOptions);

        void Remove(string key);
        Task RemoveAsync(string key);

        bool IsExistsKey(string key);
        Task<bool> IsExistsKeyAsync(string key);
    }
}
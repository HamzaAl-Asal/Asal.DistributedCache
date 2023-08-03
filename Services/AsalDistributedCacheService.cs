using Asal.DistributedCache.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Asal.DistributedCache.Services
{
    public class AsalDistributedCacheService : IAsalDistributedMemoryCache
    {
        private readonly IDistributedCache distributedCache;
        public AsalDistributedCacheService(IDistributedCache distributedCache)
        {
            this.distributedCache = distributedCache;
        }

        public T Get<T>(string key)
        {
            var json = distributedCache.GetString(key);

            if (json is null)
            {
                return default(T);
            }

            return JsonConvert.DeserializeObject<T>(json);
        }

        public async Task<T> GetAsync<T>(string key)
        {
            var json = await distributedCache.GetStringAsync(key);

            if (json is null)
            {
                return default;
            }

            return JsonConvert.DeserializeObject<T>(json);
        }

        public void Set(string key, object data, int cacheTimeInMinutes = 60)
        {
            var json = JsonConvert.SerializeObject(data);

            var expiresIn = TimeSpan.FromMinutes(cacheTimeInMinutes);

            var options = new DistributedCacheEntryOptions()
                .SetAbsoluteExpiration(expiresIn);

            distributedCache.SetString(key, json, options);
        }

        public async Task SetAsync(string key, object data, int cacheTimeInMinutes = 60)
        {
            var json = JsonConvert.SerializeObject(data);

            var expiresIn = TimeSpan.FromMinutes(cacheTimeInMinutes);

            var options = new DistributedCacheEntryOptions()
                .SetAbsoluteExpiration(expiresIn);

            await distributedCache.SetStringAsync(key, json, options);
        }

        public void Remove(string key)
        {
            distributedCache.Remove(key);
        }

        public async Task RemoveAsync(string key)
        {
            await distributedCache.RemoveAsync(key);
        }

        public bool IsExistedKey(string key)
        {
            var result = distributedCache.Get(key);

            if (result is null)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> IsExistedKeyAsync(string key)
        {
            var result = await distributedCache.GetAsync(key);

            if (result is null)
            {
                return false;
            }

            return true;
        }
    }
}
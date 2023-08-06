
using Asal.DistributedCache.Interfaces;
using Asal.DistributedCache.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Asal.DistributedCache
{
    public static class ServiceCollectionExtention
    {
        public static void AddAsalDistributedCache(this IServiceCollection services)
        {
            services.AddDistributedMemoryCache();
            services.TryAddSingleton<IAsalDistributedMemoryCache, AsalDistributedCacheService>();
        }
    }
}
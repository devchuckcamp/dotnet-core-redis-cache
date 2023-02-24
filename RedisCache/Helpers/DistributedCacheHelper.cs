using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace RedisCache.Helpers;

public static class DistributedCacheHelper
{
    public static async Task SetRecordAsync<T>(
            this IDistributedCache cache,
            string recordId,
            T data,
            TimeSpan? ExpireTime = null,
            TimeSpan? UnusedExpireTime = null
        )
    {
        var options = new DistributedCacheEntryOptions();

        options.AbsoluteExpirationRelativeToNow = ExpireTime ?? TimeSpan.FromSeconds( 60 );
        options.SlidingExpiration = UnusedExpireTime;

        var jsonData = JsonSerializer.Serialize( data );
        await cache.SetStringAsync( recordId, jsonData, options );
    }

    public static async Task<T?> GetRecordAsync<T>(
        this IDistributedCache cache,
        string recordId
        )
    {
        var jsonData = await cache.GetStringAsync( recordId );
        if(jsonData is null)
        {
            return default;
        }

        return JsonSerializer.Deserialize<T>(jsonData);
    }
}
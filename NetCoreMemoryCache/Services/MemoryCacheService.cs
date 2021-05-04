using Microsoft.Extensions.Caching.Memory;
using NetCoreMemoryCache.Entities;
using System;
using System.Collections.Generic;

namespace NetCoreMemoryCache.Services
{
    public class MemoryCacheService : IMemoryCacheService
    {
        private readonly IMemoryCache _memoryCache;
        private const string COUNTRIES_KEY = "Countries";

        public MemoryCacheService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public IEnumerable<Country> GetCacheData()
        {
            if (_memoryCache.TryGetValue(COUNTRIES_KEY, out List<Country> countries))
                return countries;

            return default;
        }

        public void CreateCache(IEnumerable<Country> newCountries)
        {
            var memoryCacheEntryOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(3600),
                SlidingExpiration = TimeSpan.FromSeconds(1200) //se nao for acessado , é retirado da memoria
            };

            _memoryCache.Set(COUNTRIES_KEY, newCountries, memoryCacheEntryOptions);
        }
    }
}

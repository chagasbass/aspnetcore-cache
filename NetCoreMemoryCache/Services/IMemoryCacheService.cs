using NetCoreMemoryCache.Entities;
using System.Collections.Generic;

namespace NetCoreMemoryCache.Services
{
    public interface IMemoryCacheService
    {
        IEnumerable<Country> GetCacheData();
        void CreateCache(IEnumerable<Country> newCountries);
    }
}

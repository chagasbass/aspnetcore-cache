using NetCoreMemoryCache.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetCoreMemoryCache.Services
{
    public interface ICountryService
    {
        Task<IEnumerable<Country>> GetCountriesAsync();
    }
}

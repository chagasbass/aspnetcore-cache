using Microsoft.AspNetCore.Mvc;
using NetCoreMemoryCache.Entities;
using NetCoreMemoryCache.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetCoreMemoryCache.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryService _countryService;
        private readonly IMemoryCacheService _memoryCacheService;

        public CountriesController(ICountryService countryService, IMemoryCacheService memoryCacheService)
        {
            _countryService = countryService;
            _memoryCacheService = memoryCacheService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Country>>> GetCountriesAsync()
        {

            var countries = _memoryCacheService.GetCacheData();

            if (countries is null)
            {
                var newCountries = await _countryService.GetCountriesAsync();
                _memoryCacheService.CreateCache(newCountries);

                return Ok(newCountries);
            }

            return Ok(countries);
        }
    }
}

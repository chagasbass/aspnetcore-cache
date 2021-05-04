using Microsoft.Extensions.Options;
using NetCoreMemoryCache.Configurations;
using NetCoreMemoryCache.Entities;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace NetCoreMemoryCache.Services
{
    public class CountryService : ICountryService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly ApiConfigOptions _apiConfigOptions;

        public CountryService(IHttpClientFactory clientFactory, IOptions<ApiConfigOptions> options)
        {
            _clientFactory = clientFactory;
            _apiConfigOptions = options.Value;
        }

        public async Task<IEnumerable<Country>> GetCountriesAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, _apiConfigOptions.BaseURL);

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();

                var countries = JsonSerializer.Deserialize<List<Country>>(data, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                return countries;
            }

            return default;
        }
    }
}

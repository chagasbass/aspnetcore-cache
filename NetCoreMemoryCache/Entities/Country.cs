using System.Text.Json.Serialization;

namespace NetCoreMemoryCache.Entities
{
    public class Country
    {
        [JsonInclude]
        public string Name { get; set; }
        [JsonInclude]
        public string Capital { get; set; }
        [JsonInclude]
        public string Region { get; set; }
        [JsonInclude]
        public string Flag { get; set; }
        [JsonInclude]
        public string Alpha2Code { get; set; }
        [JsonInclude]
        public string Demonym { get; set; }
    }
}

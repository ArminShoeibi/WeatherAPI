using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WeatherAPI.Models
{
    /// <summary>
    /// Location object is returned with each API response. 
    /// It is actually the matched location for which the information has been returned.
    /// It returns information about the location including geo points, name,
    /// region, country and time zone information as well.
    /// </summary>
    public record Location
    {

        [JsonPropertyName("lat")]
        public decimal Latitude { get; init; }

        [JsonPropertyName("lon")]
        public decimal Longitude { get; init; }

        [JsonPropertyName("name")]
        public string Name { get; init; }

        [JsonPropertyName("region")]
        public string Region { get; init; }

        [JsonPropertyName("country")]
        public string Country { get; init; }

        [JsonPropertyName("tz_id")]
        public string Timezone { get; init; }

        [JsonPropertyName("localtime_epoch")]
        public int LocalTimeEpoch { get; init; }

        [JsonPropertyName("localtime")]
        public string LocalTime { get; init; }
    }
}

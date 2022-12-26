using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Minimal_Web_API
{
    public class TransportStop
    {
        [JsonProperty("stopId")]
        public string StopId { get; set; }

        [JsonProperty("stopName")]
        public string Name { get; set; }

        [JsonProperty("subName")]
        public string SubName { get; set; }

        [JsonProperty("zoneName")]
        public string ZoneName { get; set; }
    }
}
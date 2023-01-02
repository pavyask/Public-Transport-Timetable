using Newtonsoft.Json;

namespace Minimal_Web_API
{
    public class StopTimetableItem
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("routeId")]
        public string RouteId { get; set; }

        [JsonProperty("headsign")]
        public string HeadSign { get; set; }

        [JsonProperty("theoreticalTime")]
        public string TheoreticalTime { get; set; }

        [JsonProperty("estimatedTime")]
        public string EstimatedTime { get; set; }

        [JsonProperty("delayInSeconds")]
        public int DelayInSeconds { get; set; }
    }
}
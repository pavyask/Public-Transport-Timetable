using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

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
        public DateTime TheoreticalTime { get; set; }

        [JsonProperty("estimatedTime")]
        public DateTime EstimatedTime { get; set; }

        [JsonProperty("delayInSeconds")]
        public int DelayInSeconds { get; set; }
    }
}
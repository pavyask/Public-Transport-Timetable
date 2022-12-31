using Newtonsoft.Json;

namespace Minimal_Web_API.Models
{
    public class StopTimetable
    {
        [JsonProperty("lastUpdate")]
        public DateTime LastUpdate { get; set; }

        [JsonProperty("delay")]
        public IEnumerable<StopTimetableItem> StopTimetableItems { get; set; }
    }
}
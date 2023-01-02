using Newtonsoft.Json;

namespace Minimal_Web_API.Models
{
    public class StopTimetable
    {
        [JsonProperty("lastUpdate")]
        public string LastUpdate { get; set; }

        [JsonProperty("delay")]
        public ICollection<StopTimetableItem> StopTimetableItems { get; set; } = new List<StopTimetableItem>();
    }
}
using Minimal_Web_API.Models;
using Newtonsoft.Json;

using System.ComponentModel.DataAnnotations;

namespace Minimal_Web_API.Models
{
    public class Stop
    {
        [Key]
        [JsonProperty("stopId")]
        public string StopId { get; set; }

        [JsonProperty("stopName")]
        public string Name { get; set; }

        [JsonProperty("subName")]
        public string SubName { get; set; }

        [JsonProperty("zoneName")]
        public string ZoneName { get; set; }
        
        public virtual ICollection<UserStop> UserStops { get; set; } = new List<UserStop>();


        public void OverrideValues(Stop stop)
        {
            Name = stop.Name;
            SubName = stop.SubName;
            ZoneName = stop.ZoneName;
        }
    }
}
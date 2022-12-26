using Minimal_Web_API.Models;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Minimal_Web_API
{
    public class TransportStop
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


        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}
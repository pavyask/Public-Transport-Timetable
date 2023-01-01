using Minimal_Web_API.Models;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Minimal_Web_API.DTO
{
    public class GetStopDTO
    {
        public string StopId { get; set; }

        public string Name { get; set; }

        public string SubName { get; set; }

        public string ZoneName { get; set; }
    }
}

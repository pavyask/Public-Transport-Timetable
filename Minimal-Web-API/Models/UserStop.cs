using System.Text.Json.Serialization;

namespace Minimal_Web_API.Models
{
    public class UserStop
    {       
        public string UserLogin { get; set; }
        public User User { get; set; }
        public string StopId { get; set; }
        public Stop Stop { get; set; }
    }
}

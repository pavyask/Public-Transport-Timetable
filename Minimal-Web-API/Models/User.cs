using System.ComponentModel.DataAnnotations;

namespace Minimal_Web_API.Models
{
    public class User
    {
        [Key]
        public string Login { get; set; }

        public string Password { get; set; }

        public virtual ICollection<TransportStop> TransportStops { get; set; } = new List<TransportStop>();
    }
}
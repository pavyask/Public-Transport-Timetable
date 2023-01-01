using System.ComponentModel.DataAnnotations;

namespace Minimal_Web_API.Models
{
    public class User
    {
        [Key]
        public string Login { get; set; }

        public string Password { get; set; }

        public virtual ICollection<UserStop> UserStops { get; set; } = new List<UserStop>();
    }
}
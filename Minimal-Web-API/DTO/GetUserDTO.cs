using Minimal_Web_API.Models;
using System.ComponentModel.DataAnnotations;

namespace Minimal_Web_API.DTO
{
    public class GetUserDTO
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public virtual ICollection<string> UserStopIds { get; set; } = new List<string>();
    }
}

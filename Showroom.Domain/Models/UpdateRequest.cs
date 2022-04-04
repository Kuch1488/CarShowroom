using System.ComponentModel.DataAnnotations;

namespace Showroom.Domain.Models
{
    public class UpdateRequest
    {
        public int IdUser { get; set; }
        public string UserName { get; set; } = null!;

        [EmailAddress]
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;

        public string Password { get; set; } = null!;
    }
}

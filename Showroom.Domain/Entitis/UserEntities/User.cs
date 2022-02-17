using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Showroom.Domain.Entitis.UserEntities
{
    public partial class User
    {
        public User()
        {
            Wishlists = new HashSet<Wishlist>();
        }

        public int IdUser { get; set; }
        public string UserName { get; set; } = null!;

        [EmailAddress]
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;

        [JsonIgnore]
        public string Password { get; set; } = null!;

        public virtual ICollection<Wishlist> Wishlists { get; set;}
    }
}

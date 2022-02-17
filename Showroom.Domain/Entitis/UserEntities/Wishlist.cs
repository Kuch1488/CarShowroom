using Showroom.Domain.Entities;
using System.Text.Json.Serialization;

namespace Showroom.Domain.Entitis.UserEntities
{
    public partial class Wishlist
    {
        public int IdWishlist { get; set; }
        public DateTime Date { get; set; }

        [JsonIgnore]
        public int IdUser { get; set; }
        [JsonIgnore]
        public int IdCar { get; set; }

        public virtual User? IdUserNavigation { get; set; }
        public virtual Car? IdCarNavigation { get; set; }
    }
}

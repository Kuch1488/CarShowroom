using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Showroom.Domain.Entities
{
    public partial class CarShowroom
    {
        public CarShowroom()
        {
            Cars = new HashSet<Car>();
        }

        public int IdShowroom { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Phone { get; set; } = null!;

        [EmailAddress]
        public string Email { get; set; } = null!;

        [JsonIgnore]
        public virtual ICollection<Car> Cars { get; set; }
    }
}

using System.Text.Json.Serialization;

namespace Showroom.Domain.Entities
{
    public partial class Car
    {
        public Car()
        {
            StateElements = new HashSet<StateElement>();
        }

        public string VinNumber { get; set; } = null!;
        public string Colour { get; set; } = null!;
        public decimal Price { get; set; }
        [JsonIgnore]
        public int IdShowroom { get; set; }
        [JsonIgnore]
        public int IdModel { get; set; }
        
        public virtual Model? IdModelNavigation { get; set; }
        public virtual CarShowroom? IdShowroomNavigation { get; set; }

        [JsonIgnore]
        public virtual ICollection<StateElement> StateElements { get; set; }
    }
}

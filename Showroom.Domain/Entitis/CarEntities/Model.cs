using System.Text.Json.Serialization;

namespace Showroom.Domain.Entities
{
    public partial class Model
    {
        public Model()
        {
            Cars = new HashSet<Car>();
        }

        public int IdModel { get; set; }
        public string Name { get; set; } = null!;
        [JsonIgnore]
        public int IdBody { get; set; }
        [JsonIgnore]
        public int IdBrand { get; set; }
        [JsonIgnore]
        public int IdClass { get; set; }
        [JsonIgnore]
        public int IdGearbox { get; set; }
        [JsonIgnore]
        public int IdGeneration { get; set; }
        [JsonIgnore]
        public int IdEngine { get; set; }

        [JsonIgnore]
        public virtual ICollection<Car> Cars { get; set; }

        public virtual Body? IdBodyNavigation { get; set; }
        public virtual Brand? IdBrandNavigation { get; set; }
        public virtual Class? IdClassNavigation { get; set; }
        public virtual Gearbox? IdGearboxNavigation { get; set; }
        public virtual Generation? IdGenerationNavigation { get; set; }
        public virtual Engine? IdEngineNavigation { get; set; }
    }
}

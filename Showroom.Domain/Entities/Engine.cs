using System.Text.Json.Serialization;

namespace Showroom.Domain.Entities
{
    public partial class Engine
    {
        public Engine()
        {
            Models = new HashSet<Model>();
        }

        public int IdEngine { get; set; }
        public string Type { get; set; } = null!;
        public int Volume { get; set; }
        public int HP { get; set; }
        public int Consumption { get; set; }

        [JsonIgnore]
        public virtual ICollection<Model> Models { get; set; }
     }
}

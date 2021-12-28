using System.Text.Json.Serialization;

namespace Showroom.Domain.Entities
{
    public partial class Body
    {
        public Body()
        {
            Models = new HashSet<Model>();
        }

        public int IdBody { get; set; }
        public string Name { get; set; } = null!;
        public int Volume { get; set; }
        public int Door { get; set; }

        [JsonIgnore]
        public virtual ICollection<Model> Models { get; set; } 
    }
}

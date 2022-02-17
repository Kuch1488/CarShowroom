using System.Text.Json.Serialization;

namespace Showroom.Domain.Entities
{
    public partial class Gearbox
    {
        public Gearbox()
        {
            Models = new HashSet<Model>();
        }

        public int IdGearbox { get; set; }
        public string Type { get; set; } = null!;
        public int Number { get; set; }

        [JsonIgnore]
        public virtual ICollection<Model> Models { get; set; }
    }
}

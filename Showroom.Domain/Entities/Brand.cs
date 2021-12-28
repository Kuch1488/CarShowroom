using System.Text.Json.Serialization;

namespace Showroom.Domain.Entities
{
    public partial class Brand
    {
        public Brand()
        {
            Models = new HashSet<Model>();
        }

        public int IdBrand { get; set; }
        public string Name { get; set; } = null!;

        [JsonIgnore]
        public virtual ICollection<Model> Models { get; set; }
    }
}

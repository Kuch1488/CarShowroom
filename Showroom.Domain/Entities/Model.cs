using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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
        public int IdBody { get; set; }
        public int IdBrand { get; set; }
        public int IdClass { get; set; }
        public int IdGearbox { get; set; }
        public int IdGeneration { get; set; }
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

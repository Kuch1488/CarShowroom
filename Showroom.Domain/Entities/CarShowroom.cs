using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public virtual ICollection<Car> Cars { get; set; }
    }
}

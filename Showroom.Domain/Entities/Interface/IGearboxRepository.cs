using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Showroom.Domain.Entities.Interface
{
    public interface IGearboxRepository
    {
        Task<IEnumerable<Gearbox>> GetGearboxes();
        Task<Gearbox> GetGearbox(int id);
        Task<Gearbox> Create(Gearbox gearbox);
        Task Update(Gearbox gearbox);
        Task Delete(int id);
    }
}

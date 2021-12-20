using Microsoft.EntityFrameworkCore;
using Showroom.Domain;
using Showroom.Domain.Entities;
using Showroom.Domain.Entities.Interface;

namespace Showroom.Infrastructure.Repository
{
    public class GearboxRepository : IGearboxRepository
    {
        private readonly Context _context;
        public GearboxRepository(Context context) => _context = context;

        public async Task<Gearbox> Create(Gearbox gearbox)
        {
            _context.Gearboxes.Add(gearbox);
            await _context.SaveChangesAsync();
            return gearbox;
        }

        public async Task Delete(int id)
        {
            var gearboxToDelete = await _context.Gearboxes.FindAsync(id);

            if(gearboxToDelete == null) throw new Exception("Record doesn't exist");

            _context.Gearboxes.Remove(gearboxToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<Gearbox> GetGearbox(int id)
        {
            if(!await _context.Gearboxes.AnyAsync(o => o.IdGearbox == id)) throw new Exception("Record doesn't exist");
            return await _context.Gearboxes.FindAsync(id);
        }

        public async Task<IEnumerable<Gearbox>> GetGearboxes()
        {
            return await _context.Gearboxes.ToListAsync();
        }

        public async Task Update(Gearbox gearbox)
        {
            _context.Entry(gearbox).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}

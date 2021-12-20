using Microsoft.EntityFrameworkCore;
using Showroom.Domain;
using Showroom.Domain.Entities;
using Showroom.Domain.Entities.Interface;

namespace Showroom.Infrastructure.Repository
{
    public class ShowroomRepository : IShowroomRepository
    {
        private readonly Context _context;
        public ShowroomRepository(Context context) => _context = context;

        public async Task<CarShowroom> Create(CarShowroom carShowroom)
        {
            _context.Showrooms.Add(carShowroom);
            await _context.SaveChangesAsync();
            return carShowroom;
        }

        public async Task Delete(int id)
        {
            var showroomToDelete = await _context.Showrooms.FindAsync(id);

            if (showroomToDelete == null) throw new Exception("Record doesn't exist");

            _context.Showrooms.Remove(showroomToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<CarShowroom> GetShowroom(int id)
        {
            if(!await _context.Showrooms.AnyAsync(o => o.IdShowroom == id)) throw new Exception("Record doesn't exist");
            return await _context.Showrooms.FindAsync(id);
        }

        public async Task<IEnumerable<CarShowroom>> GetShowrooms()
        {
            return await _context.Showrooms.ToListAsync();
        }

        public async Task Update(CarShowroom carShowroom)
        {
            _context.Entry(carShowroom).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}

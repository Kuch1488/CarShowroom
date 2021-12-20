using Microsoft.EntityFrameworkCore;
using Showroom.Domain;
using Showroom.Domain.Entities;
using Showroom.Domain.Entities.Interface;

namespace Showroom.Infrastructure.Repository
{
    public class ClassRepository : IClassRepository
    {
        private readonly Context _context;
        public ClassRepository(Context context) => _context = context;

        public async Task<Class> Create(Class @class)
        {
            _context.Classs.Add(@class);
            await _context.SaveChangesAsync();
            return @class;
        }

        public async Task Delete(int id)
        {
            var classToDelete = await _context.Classs.FindAsync(id);

            if (classToDelete == null) throw new Exception("Record doesn't exist");

            _context.Classs.Remove(classToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<Class> GetClass(int id)
        {
            if(!await _context.Classs.AnyAsync(o => o.IdClass == id)) throw new Exception("Record doesn't exist");

            return await _context.Classs.FindAsync(id);
        }

        public async Task<IEnumerable<Class>> GetClasses()
        {
            return await _context.Classs.ToListAsync();
        }

        public async Task Update(Class @class)
        {
            _context.Entry(@class).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}

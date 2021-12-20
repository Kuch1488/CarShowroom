using Microsoft.EntityFrameworkCore;
using Showroom.Domain;
using Showroom.Domain.Entities;
using Showroom.Domain.Entities.Interface;

namespace Showroom.Infrastructure.Repository
{
    public class EngineRepository : IEngineRepository
    {
        private readonly Context _context;
        public EngineRepository(Context context) => _context = context;
         
        public async Task<Engine> Create(Engine engine)
        {
            _context.Engines.Add(engine);
            await _context.SaveChangesAsync();
            return engine;
        }

        public async Task Delete(int id)
        {
            var engineToDelete = await _context.Engines.FindAsync(id);

            if(engineToDelete == null) throw new Exception("Record doesn't exist");

            _context.Engines.Remove(engineToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<Engine> GetEngine(int id)
        {
            if(!await _context.Engines.AnyAsync(o => o.IdEngine == id)) throw new Exception("Record doesn't exist");
            return await _context.Engines.FindAsync(id);
        }

        public async Task<IEnumerable<Engine>> GetEngines()
        {
            return await _context.Engines.ToListAsync();
        }

        public async Task Update(Engine engine)
        {
            _context.Entry(engine).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}

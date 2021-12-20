using Microsoft.EntityFrameworkCore;
using Showroom.Domain;
using Showroom.Domain.Entities;
using Showroom.Domain.Entities.Interface;

namespace Showroom.Infrastructure.Repository
{
    public class GenerationRepository : IGenerationRepository
    {
        private readonly Context _context;
        public GenerationRepository(Context context) => _context = context;

        public async Task<Generation> Create(Generation generation)
        {
            _context.Generes.Add(generation);
            await _context.SaveChangesAsync();
            return generation;
        }

        public async Task Delete(int id)
        {
            var generationToDelete = await _context.Generes.FindAsync(id);

            if(generationToDelete == null) throw new Exception("Record doesn't exist");

            _context.Generes.Remove(generationToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<Generation> GetGeneration(int id)
        {
            if(!await _context.Generes.AnyAsync(o => o.IdGeneration == id)) throw new Exception("Record doesn't exist");
            return await _context.Generes.FindAsync(id);
        }

        public async Task<IEnumerable<Generation>> GetGenerations()
        {
            return await _context.Generes.ToListAsync();
        }

        public async Task Update(Generation generation)
        {
            _context.Entry(generation).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}

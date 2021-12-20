using Microsoft.EntityFrameworkCore;
using Showroom.Domain;
using Showroom.Domain.Entities;
using Showroom.Domain.Entities.Interface;

namespace Showroom.Infrastructure.Repository
{
    public class ModelOptionRepository : IModelOptionRepository
    {
        private readonly Context _context;
        public ModelOptionRepository(Context context) => _context = context;

        public async Task<ModelOption> Create(ModelOption modelOption)
        {
            _context.ModelOptions.Add(modelOption);
            await _context.SaveChangesAsync();
            return modelOption;
        }

        public async Task Delete(int id)
        {
            var modelOptionToDelete = await _context.ModelOptions.FindAsync(id);

            if(modelOptionToDelete == null) throw new Exception("Record doesn't exist");

            _context.ModelOptions.Remove(modelOptionToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<ModelOption> GetModelOption(int id)
        {
            if(!await _context.ModelOptions.AnyAsync(o => o.IdModel == id)) throw new Exception("Record doesn't exist");
            return await _context.ModelOptions.FindAsync(id);
        }

        public async Task<IEnumerable<ModelOption>> GetModelOptions()
        {
            return await _context.ModelOptions.ToListAsync();
        }

        public async Task Update(ModelOption modelOption)
        {
            _context.Entry(modelOption).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}

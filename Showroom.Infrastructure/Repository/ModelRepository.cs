using Microsoft.EntityFrameworkCore;
using Showroom.Domain;
using Showroom.Domain.Entities;
using Showroom.Domain.Entities.Interface;

namespace Showroom.Infrastructure.Repository
{
    public class ModelRepository : IModelRepository
    {
        private readonly Context _context;
        public ModelRepository(Context context) => _context = context;

        public async Task<Model> Create(Model model)
        {
            _context.Models.Add(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task Delete(int id)
        {
            var modelToDelete = await _context.Models.FindAsync(id);

            if(modelToDelete == null) throw new Exception("Record doesn't exist");

            _context.Models.Remove(modelToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<Model> GetModel(int id)
        {
            if(!await _context.Models.AnyAsync(o => o.IdModel == id)) throw new Exception("Record doesn't exist");
            return await _context.Models.FindAsync(id);
        }

        public async Task<IEnumerable<Model>> GetModels()
        {
            return await _context.Models.ToListAsync();
        }

        public async Task Update(Model model)
        {
            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}

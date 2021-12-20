using Microsoft.EntityFrameworkCore;
using Showroom.Domain;
using Showroom.Domain.Entities;
using Showroom.Domain.Entities.Interface;

namespace Showroom.Infrastructure.Repository
{
    public class OptionRepository : IOptionRepository
    {
        private readonly Context _context;
        public OptionRepository(Context context) => _context = context;

        public async Task<Option> Create(Option option)
        {
            _context.Options.Add(option);
            await _context.SaveChangesAsync();
            return option;
        }

        public async Task Delete(int id)
        {
            var optionToDelete = await _context.Options.FindAsync(id);

            if (optionToDelete == null) throw new Exception("Record doesn't exist");

            _context.Options.Remove(optionToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<Option> GetOption(int id)
        {
            if(!await _context.Options.AnyAsync(o => o.IdOption == id)) throw new Exception("Record doesn't exist");
            return await _context.Options.FindAsync(id);
        }

        public async Task<IEnumerable<Option>> GetOptions()
        {
            return await _context.Options.ToListAsync();
        }

        public async Task Update(Option option)
        {
            _context.Entry(option).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}

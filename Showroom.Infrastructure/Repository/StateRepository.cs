using Microsoft.EntityFrameworkCore;
using Showroom.Domain;
using Showroom.Domain.Entities;
using Showroom.Domain.Entities.Interface;

namespace Showroom.Infrastructure.Repository
{
    public class StateRepository : IStateRepository
    {
        private readonly Context _context;
        public StateRepository(Context context) => _context = context;

        public async Task<State> Create(State state)
        {
            _context.State.Add(state);
            await _context.SaveChangesAsync();
            return state;
        }

        public async Task Delete(int id)
        {
            var stateToDelete = await _context.State.FindAsync(id);

            if (stateToDelete == null) throw new Exception("Record doesn't exist");

            _context.State.Remove(stateToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<State> GetState(int id)
        {
            if(!await _context.State.AnyAsync(o => o.IdState == id)) throw new Exception("Record doesn't exist");
            return await _context.State.FindAsync(id);
        }

        public async Task<IEnumerable<State>> GetStates()
        {
            return await _context.State.ToListAsync();
        }

        public async Task Update(State state)
        {
            _context.Entry(state).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}

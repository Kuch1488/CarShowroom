using Microsoft.EntityFrameworkCore;
using Showroom.Domain;
using Showroom.Domain.Entities;
using Showroom.Domain.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Showroom.Infrastructure.Repository
{
    public class StateElementRepository : IStateElementRepository
    {
        private readonly Context _context;
        public StateElementRepository(Context context) => _context = context;

        public async Task<StateElement> Create(StateElement stateElement)
        {
            _context.StateElements.Add(stateElement);
            await _context.SaveChangesAsync();
            return stateElement;
        }

        public async Task Delete(int id)
        {
            var stateElementToDelete = await _context.StateElements.FindAsync(id);

            if (stateElementToDelete == null) throw new Exception("Record doesn't exist");

            _context.StateElements.Remove(stateElementToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<StateElement> GetStateElement(int id)
        {
            if(!await _context.StateElements.AnyAsync(o => o.IdStateElement == id)) throw new Exception("Record doesn't exist");
            return await _context.StateElements.FindAsync(id);
        }

        public async Task<IEnumerable<StateElement>> GetStateElements()
        {
            return await _context.StateElements.ToListAsync();
        }

        public async Task Update(StateElement stateElement)
        {
            _context.Entry(stateElement).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}

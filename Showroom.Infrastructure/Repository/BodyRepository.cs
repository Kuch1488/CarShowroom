using Microsoft.EntityFrameworkCore;
using Showroom.Domain;
using Showroom.Domain.Entities;
using Showroom.Domain.Entities.Interface;

namespace Showroom.Infrastructure.Repository
{
    public class BodyRepository : IBodyRepository
    {
        private readonly Context _context;

        public BodyRepository(Context context) => _context = context;

        public async Task<Body> Create(Body body)
        {
            _context.Bodies.Add(body);
            await _context.SaveChangesAsync();
            return body;
        }

        public async Task Delete(int id)
        {
            var bodyToDelete = await _context.Bodies.FindAsync(id);

            if(bodyToDelete == null) throw new Exception("Record doesn't exist");

            _context.Bodies.Remove(bodyToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Body>> GetBodies()
        {
            return await _context.Bodies.ToListAsync();
        }

        public async Task<Body> GetBody(int id)
        {
            if(!await _context.Bodies.AnyAsync(o => o.idBody == id)) throw new Exception("Record doesn't exist");
            return await _context.Bodies.FindAsync(id);
        }

        public async Task Update(Body body)
        {
            _context.Entry(body).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}

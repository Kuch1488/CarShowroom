using Microsoft.EntityFrameworkCore;
using Showroom.Domain;
using Showroom.Domain.Entities;
using Showroom.Domain.Entities.Interface;

namespace Showroom.Infrastructure.Repository
{
    public class BrandRepository : IBrandRepository
    {
        private readonly Context _context;

        public BrandRepository(Context context) => _context = context;

        public async Task<Brand> Create(Brand brand)
        {
            _context.Brands.Add(brand);
            await _context.SaveChangesAsync();
            return brand;
        }

        public async Task Delete(int id)
        {
            var brandToDelete = await _context.Brands.FindAsync(id);

            if(brandToDelete == null) throw new Exception("Record doesn't exist");

            _context.Brands.Remove(brandToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<Brand> GetBrand(int id)
        {
            if(!await _context.Brands.AnyAsync(o => o.IdBrand == id)) throw new Exception("Record doesn't exist");
            return await _context.Brands.FindAsync(id);
        }

        public async Task<IEnumerable<Brand>> GetBrands()
        {
            return await _context.Brands.ToListAsync();
        }

        public async Task Update(Brand brand)
        {
            _context.Entry(brand).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}

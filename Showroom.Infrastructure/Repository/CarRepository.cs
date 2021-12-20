using Showroom.Domain;
using Showroom.Domain.Entities;
using Showroom.Domain.Entities.Interface;
using Microsoft.EntityFrameworkCore;

namespace Showroom.Infrastructure.Repository
{
    public class CarRepository : ICarRepository
    {
        private readonly Context _context;
        public CarRepository(Context context) => _context = context;

        public async Task<Car> Create(Car car)
        {
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();
            return car;
        }

        public async Task Delete(string vin_number)
        {
            var carToDelete = await _context.Cars.FindAsync(vin_number);

            if(carToDelete == null) throw new Exception("Record doesn't exist");

            _context.Cars.Remove(carToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<Car> GetCar(string vin_number)
        {
            if(!await _context.Cars.AnyAsync(o => o.VinNumber == vin_number)) throw new Exception("Record doesn't exist");
            return await _context.Cars.FindAsync(vin_number);
        }

        public async Task<IEnumerable<Car>> GetCars()
        {
            return await _context.Cars.ToListAsync();
        }

        public async Task Update(Car car)
        {
            _context.Entry(car).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}

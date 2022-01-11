using System.Collections;

namespace Showroom.Domain.Entities.Interface
{
    public interface ICarRepository
    {
        Task<IEnumerable<Car>> GetCars();
        Task<IEnumerable> GetCar(string vin_number);
        Task<Car> Create(Car car);
        Task Update(Car car);
        Task Delete(string vin_number);
    }
}

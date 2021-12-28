using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Showroom.Domain.Entities;
using Showroom.Domain.Entities.Interface;

namespace Showroom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarRepository _carRepository;
        public CarController(ICarRepository carRepository) => _carRepository = carRepository;

        [HttpGet]
        [Route("all")]
        public async Task<IEnumerable<Car>> GetCars() => await _carRepository.GetCars();

        [HttpGet]
        [Route("{vin_number}")]
        public async Task<ActionResult<Car>> GetCar(string vin_number)
        {
            try
            {
                return await _carRepository.GetCar(vin_number);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<Car>> PostCar([FromBody] Car car)
        {
            try
            {
                Car newCar = await _carRepository.Create(car);
                return CreatedAtAction(nameof(GetCar), new { vin_number = newCar.VinNumber }, newCar);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("update")]
        public async Task<ActionResult<Car>> PutCar([FromBody] Car car)
        {
            try
            {
                await _carRepository.Update(car);
                return CreatedAtAction(nameof(GetCar), new {vin_number = car.VinNumber}, car);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{vin_number}")]
        public async Task<ActionResult> DeleteCar(string vin_number)
        {
            try
            {
                await _carRepository.Delete(vin_number);
                return Ok(new { message = "car deleted successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

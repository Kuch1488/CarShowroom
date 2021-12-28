using Microsoft.AspNetCore.Mvc;
using Showroom.Domain.Entities;
using Showroom.Domain.Entities.Interface;

namespace Showroom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowroomController : ControllerBase
    {
        private readonly IShowroomRepository _showroomRepository;
        public ShowroomController(IShowroomRepository showroomRepository) => _showroomRepository = showroomRepository;

        [HttpGet]
        [Route("all")]
        public async Task<IEnumerable<CarShowroom>> GetShowrooms() => await _showroomRepository.GetShowrooms();

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<CarShowroom>> GetShowroom(int id)
        {
            try
            {
                return await _showroomRepository.GetShowroom(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<CarShowroom>> PostShowroom([FromBody] CarShowroom carShowroom)
        {
            try
            {
                CarShowroom newShowroom = await _showroomRepository.Create(carShowroom);
                return CreatedAtAction(nameof(GetShowroom), new { id = newShowroom.IdShowroom }, newShowroom);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("update")]
        public async Task<ActionResult<CarShowroom>> PutShowroom([FromBody] CarShowroom carShowroom)
        {
            try
            {
                await _showroomRepository.Update(carShowroom);
                return CreatedAtAction(nameof(GetShowroom), new {id = carShowroom.IdShowroom}, carShowroom);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteShowroom(int id)
        {
            try
            {
                await _showroomRepository.Delete(id);
                return Ok(new { message = "showroom deleted successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

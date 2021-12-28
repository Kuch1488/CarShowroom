using Microsoft.AspNetCore.Mvc;
using Showroom.Domain.Entities;
using Showroom.Domain.Entities.Interface;

namespace Showroom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GearboxController : ControllerBase
    {
        private readonly IGearboxRepository _gearboxRepository;
        public GearboxController(IGearboxRepository gearboxRepository) => _gearboxRepository = gearboxRepository;

        [HttpGet]
        [Route("all")]
        public async Task<IEnumerable<Gearbox>> GetGearboxes() => await _gearboxRepository.GetGearboxes();

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Gearbox>> GetGearbox(int id)
        {
            try
            {
                return await _gearboxRepository.GetGearbox(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<Gearbox>> PostGearbox([FromBody] Gearbox gearbox)
        {
            try
            {
                Gearbox newGearbox = await _gearboxRepository.Create(gearbox);
                return CreatedAtAction(nameof(GetGearbox), new {id = newGearbox.IdGearbox}, newGearbox);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("update")]
        public async Task<ActionResult<Gearbox>> PutGearbox([FromBody] Gearbox gearbox)
        {
            try
            {
                await _gearboxRepository.Update(gearbox);
                return CreatedAtAction(nameof(GetGearbox), new {id = gearbox.IdGearbox}, gearbox);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteGearbox(int id)
        {
            try
            {
                await _gearboxRepository.Delete(id);
                return Ok(new {message = "gearbox deleted successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

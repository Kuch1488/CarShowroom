using Microsoft.AspNetCore.Mvc;
using Showroom.Domain.Entities;
using Showroom.Domain.Entities.Interface;

namespace Showroom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EngineController : ControllerBase
    {
        private readonly IEngineRepository _engineRepository;
        public EngineController(IEngineRepository engineRepository) => _engineRepository = engineRepository;

        [HttpGet]
        [Route("all")]
        public async Task<IEnumerable<Engine>> GetEngines() => await _engineRepository.GetEngines();

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Engine>> GetEngine(int id)
        {
            try
            {
                return await _engineRepository.GetEngine(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<Engine>> PostEngine([FromBody] Engine engine)
        {
            try
            {
                Engine newEngine = await _engineRepository.Create(engine);
                return CreatedAtAction(nameof(GetEngine), new {id = newEngine.IdEngine}, newEngine);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("update")]
        public async Task<ActionResult<Engine>> PutEngine([FromBody] Engine engine)
        {
            try
            {
                await _engineRepository.Update(engine);
                return CreatedAtAction(nameof(GetEngine), new {id = engine.IdEngine}, engine);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteEngine(int id)
        {
            try
            {
                await _engineRepository.Delete(id);
                return Ok(new { message = "engine deleted successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

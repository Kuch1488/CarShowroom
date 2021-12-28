using Microsoft.AspNetCore.Mvc;
using Showroom.Domain.Entities;
using Showroom.Domain.Entities.Interface;

namespace Showroom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenerationController : ControllerBase
    {
        private readonly IGenerationRepository _generationRepository;
        public GenerationController(IGenerationRepository generationRepository) => _generationRepository = generationRepository;

        [HttpGet]
        [Route("all")]
        public async Task<IEnumerable<Generation>> GetGenerations() => await _generationRepository.GetGenerations();

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Generation>> GetGeneration(int id)
        {
            try
            {
                return await _generationRepository.GetGeneration(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<Generation>> PostGeneration([FromBody] Generation generation)
        {
            try
            {
                Generation newGeneration = await _generationRepository.Create(generation);
                return CreatedAtAction(nameof(GetGeneration), new {id = newGeneration.IdGeneration}, newGeneration);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("update")]
        public async Task<ActionResult<Generation>> PutGeneration([FromBody] Generation generation)
        {
            try
            {
                await _generationRepository.Update(generation);
                return CreatedAtAction(nameof(GetGeneration), new {id = generation.IdGeneration}, generation);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteGeneration(int id)
        {
            try
            {
                await _generationRepository.Delete(id);
                return Ok(new {message = "generation deleted successfully" });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

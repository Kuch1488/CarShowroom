using Microsoft.AspNetCore.Mvc;
using Showroom.Domain.Entities;
using Showroom.Domain.Entities.Interface;

namespace Showroom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateElementController : ControllerBase
    {
        private readonly IStateElementRepository _stateElementRepository;
        public StateElementController(IStateElementRepository stateElementRepository) => _stateElementRepository = stateElementRepository;

        [HttpGet]
        [Route("all")]
        public async Task<IEnumerable<StateElement>> GetStateElements() => await _stateElementRepository.GetStateElements();

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<StateElement>> GetStateElement(int id)
        {
            try
            {
                return await _stateElementRepository.GetStateElement(id); 
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<StateElement>> PostStateElement([FromBody] StateElement stateElement)
        {
            try
            {
                StateElement newStateElement = await _stateElementRepository.Create(stateElement);
                return CreatedAtAction(nameof(GetStateElement), new { id = newStateElement.IdStateElement }, newStateElement);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("update")]
        public async Task<ActionResult<StateElement>> PutStateElement([FromBody] StateElement stateElement)
        {
            try
            {
                await _stateElementRepository.Update(stateElement);
                return CreatedAtAction(nameof(GetStateElement), new {id = stateElement.IdStateElement}, stateElement);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteStateElement(int id)
        {
            try
            {
                await _stateElementRepository.Delete(id);
                return Ok(new {message = "state of element deleted successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

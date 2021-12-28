using Microsoft.AspNetCore.Mvc;
using Showroom.Domain.Entities;
using Showroom.Domain.Entities.Interface;

namespace Showroom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly IStateRepository _stateRepository;
        public StateController(IStateRepository stateRepository) => _stateRepository = stateRepository;

        [HttpGet]
        [Route("all")]
        public async Task<IEnumerable<State>> GetStates() => await _stateRepository.GetStates();

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<State>> GetState(int id)
        {
            try
            {
                return await _stateRepository.GetState(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<State>> PostState([FromBody] State state)
        {
            try
            {
                State newState = await _stateRepository.Create(state);
                return CreatedAtAction(nameof(GetState), new {id = newState.IdState}, newState);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("update")]
        public async Task<ActionResult<State>> PutState([FromBody] State state)
        {
            try
            {
                await _stateRepository.Update(state);
                return CreatedAtAction(nameof(GetState), new {id = state.IdState}, state);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _stateRepository.Delete(id);
                return Ok(new {message = "deleted successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

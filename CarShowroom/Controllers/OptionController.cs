using Microsoft.AspNetCore.Mvc;
using Showroom.Domain.Entities;
using Showroom.Domain.Entities.Interface;

namespace Showroom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OptionController : ControllerBase
    {
        private readonly IOptionRepository _optionRepository;
        public OptionController(IOptionRepository optionRepository) => _optionRepository = optionRepository;

        [HttpGet]
        [Route("all")]
        public async Task<IEnumerable<Option>> GetOptions() => await _optionRepository.GetOptions();

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Option>> GetOption(int id)
        {
            try
            {
                return await _optionRepository.GetOption(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<Option>> PostOption([FromBody] Option option)
        {
            try
            {
                Option newOption = await _optionRepository.Create(option);
                return CreatedAtAction(nameof(GetOption), new {id = newOption.IdOption}, newOption);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("update")]
        public async Task<ActionResult<Option>> PutOption([FromBody] Option option)
        {
            try
            {
                await _optionRepository.Update(option);
                return CreatedAtAction(nameof(GetOption), new {id = option.IdOption}, option);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteOptin(int id)
        {
            try
            {
                await _optionRepository.Delete(id);
                return Ok(new {message = "option deleted successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

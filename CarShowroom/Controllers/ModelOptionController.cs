using Microsoft.AspNetCore.Mvc;
using Showroom.Domain.Entities;
using Showroom.Domain.Entities.Interface;

namespace Showroom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelOptionController : ControllerBase
    {
        private readonly IModelOptionRepository _modelOptionRepository;
        public ModelOptionController(IModelOptionRepository modelOptionRepository) => _modelOptionRepository = modelOptionRepository;

        [HttpGet]
        [Route("all")]
        public async Task<IEnumerable<ModelOption>> GetModelOptions() => await _modelOptionRepository.GetModelOptions();

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ModelOption>> GetModelOption(int id)
        {
            try
            {
                return await _modelOptionRepository.GetModelOption(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<ModelOption>> PostModelOption([FromBody] ModelOption modelOption)
        {
            try
            {
                ModelOption newModelOption = await _modelOptionRepository.Create(modelOption);
                return CreatedAtAction(nameof(GetModelOption), new {id = newModelOption.IdModel}, newModelOption);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("update")]
        public async Task<ActionResult<ModelOption>> PutModelOption([FromBody] ModelOption modelOption)
        {
            try
            {
                await _modelOptionRepository.Update(modelOption);
                return CreatedAtAction(nameof(GetModelOption), new {id = modelOption.IdModel}, modelOption);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteModelOption(int id)
        {
            try
            {
                await _modelOptionRepository.Delete(id);
                return Ok(new {message = "option to model deleted successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

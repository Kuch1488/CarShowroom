using Microsoft.AspNetCore.Mvc;
using Showroom.Domain.Entities;
using Showroom.Domain.Entities.Interface;

namespace Showroom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelController : ControllerBase
    {
        private readonly IModelRepository _modelRepository;
        public ModelController(IModelRepository modelRepository) => _modelRepository = modelRepository;

        [HttpGet]
        [Route("all")]
        public async Task<IEnumerable<Model>> GetModels() => await _modelRepository.GetModels();

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Model>> GetModel(int id)
        {
            try
            {
                return await _modelRepository.GetModel(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<Model>> PostModel([FromBody] Model model)
        {
            try
            {
                Model newModel = await _modelRepository.Create(model);
                return CreatedAtAction(nameof(GetModel), new {id = newModel.IdModel}, newModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("update")]
        public async Task<ActionResult<Model>> PutModel([FromBody] Model model)
        {
            try
            {
                await _modelRepository.Update(model);
                return CreatedAtAction(nameof(GetModel), new {id = model.IdModel}, model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeletedModel(int id)
        {
            try
            {
                await _modelRepository.Delete(id);
                return Ok(new {message = "model deleted successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

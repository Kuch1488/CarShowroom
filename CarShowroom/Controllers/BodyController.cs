using Microsoft.AspNetCore.Mvc;
using Showroom.Domain.Entities;
using Showroom.Domain.Entities.Interface;

namespace Showroom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BodyController : ControllerBase
    {
        private readonly IBodyRepository _bodyRepository;
        public BodyController(IBodyRepository bodyRepository) => _bodyRepository = bodyRepository;

        [HttpGet]
        [Route("all")]
        public async Task<IEnumerable<Body>> GetBodies() => await _bodyRepository.GetBodies();

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Body>> GetBody(int id)
        {
            try
            {
                return await _bodyRepository.GetBody(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<Body>> PostBody([FromBody] Body body)
        {
            try
            {
                Body newBody = await _bodyRepository.Create(body);
                return CreatedAtAction(nameof(GetBody), new {id = newBody.IdBody} ,newBody);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("update")]
        public async Task<ActionResult<Body>> PutBody([FromBody] Body body)
        {
            try
            {
                await _bodyRepository.Update(body);
                return CreatedAtAction(nameof(GetBody), new {id = body.IdBody}, body);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteBody(int id)
        {
            try
            {
                await _bodyRepository.Delete(id);
                return Ok(new { message = "body deleted successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

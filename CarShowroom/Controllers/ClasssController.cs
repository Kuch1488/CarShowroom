using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Showroom.Domain.Entities;
using Showroom.Domain.Entities.Interface;

namespace Showroom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClasssController : ControllerBase
    {
        private readonly IClassRepository _classRepository;
        public ClasssController(IClassRepository classRepository) => _classRepository = classRepository;

        [HttpGet]
        [Route("all")]
        public async Task<IEnumerable<Class>> GetClasses() => await _classRepository.GetClasses();

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Class>> GetClass(int id)
        {
            try
            {
                return await _classRepository.GetClass(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<Class>> PostClass([FromBody] Class @class)
        {
            try
            {
                Class newClass = await _classRepository.Create(@class);
                return CreatedAtAction(nameof(GetClass), new {id = newClass.IdClass}, newClass);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }

        [HttpPut]
        [Route("update")]
        public async Task<ActionResult<Class>> PutClass([FromBody] Class @class)
        {
            try
            {
                await _classRepository.Update(@class);
                return CreatedAtAction(nameof(GetClass), new {id = @class.IdClass}, @class);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteClass(int id)
        {
            try
            {
                await _classRepository.Delete(id);
                return Ok(new { message = "class deleted successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

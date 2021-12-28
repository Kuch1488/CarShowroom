using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Showroom.Domain.Entities;
using Showroom.Domain.Entities.Interface;

namespace Showroom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandRepository _brandRepository;
        public BrandController(IBrandRepository brandRepository) => _brandRepository = brandRepository;

        [HttpGet]
        [Route("all")]
        public async Task<IEnumerable<Brand>> GetBrands() => await _brandRepository.GetBrands();

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Brand>> GetBrand(int id)
        {
            try
            {
                return await _brandRepository.GetBrand(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<Brand>> PostBrand([FromBody] Brand brand)
        {
            try
            {
                Brand newBrand = await _brandRepository.Create(brand);
                return CreatedAtAction(nameof(GetBrand), new { id = newBrand.IdBrand }, newBrand);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("update")]
        public async Task<ActionResult<Brand>> PutBrand([FromBody] Brand brand)
        {
            try
            {
                await _brandRepository.Update(brand);
                return CreatedAtAction(nameof(GetBrand), new {id = brand.IdBrand}, brand);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteBrand(int id)
        {
            try
            {
                await _brandRepository.Delete(id);
                return Ok(new { message = "brand deleted successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

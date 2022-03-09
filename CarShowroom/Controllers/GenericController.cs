using Microsoft.AspNetCore.Mvc;
using Showroom.Domain.Entitis.CarEntities.Interface;

namespace Showroom.Controllers
{
    [Route("api/[controller]")]
    public class GenericController<T> : Controller where T : class
    {
        private readonly IRepository<T> _repository;

        public GenericController(IRepository<T> repository) => _repository = repository;
        
        [HttpGet]
        public async Task<IEnumerable<T>> GetAllAsync() => await _repository.GetAll();

        [HttpGet("{id}")]
        public async Task<T> GetAsync(int id) => await _repository.GetById(id);

        [HttpPost]
        public async Task PostAsync([FromBody]T entity) => await _repository.Insert(entity);

        [HttpDelete]
        public async Task DeleteAsync(int id)
        {
            T entity = await _repository.GetById(id);
            await _repository.Delete(entity);
        }
    }
}

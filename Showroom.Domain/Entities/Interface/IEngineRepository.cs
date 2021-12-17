namespace Showroom.Domain.Entities.Interface
{
    public interface IEngineRepository
    {
        Task<IEnumerable<Engine>> GetEngines();
        Task<Engine> GetEngine(int id);
        Task<Engine> Create(Engine engine);
        Task Update(Engine engine);
        Task Delete(int id);
    }
}

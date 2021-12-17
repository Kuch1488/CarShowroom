namespace Showroom.Domain.Entities.Interface
{
    public interface IGenerationRepository
    {
        Task<IEnumerable<Generation>> GetGenerations();
        Task<Generation> GetGeneration(int id);
        Task<Generation> Create(Generation generation);
        Task Update(Generation generation);
        Task Delete(int id);
    }
}

namespace Showroom.Domain.Entities.Interface
{
    public interface IModelOptionRepository
    {
        Task<IEnumerable<ModelOption>> GetModelOptions();
        Task<ModelOption> GetModelOption(int id);
        Task<ModelOption> Create(ModelOption modelOption);
        Task Update(ModelOption modelOption);
        Task Delete(int id);
    }
}

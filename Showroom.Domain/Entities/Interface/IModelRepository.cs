namespace Showroom.Domain.Entities.Interface
{
    public interface IModelRepository
    {
        Task<IEnumerable<Model>> GetModels();
        Task<Model> GetModel(int id);
        Task<Model> Create(Model model);
        Task Update(Model model);
        Task Delete(int id);
    }
}

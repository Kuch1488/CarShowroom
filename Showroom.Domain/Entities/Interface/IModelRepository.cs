using System.Collections;

namespace Showroom.Domain.Entities.Interface
{
    public interface IModelRepository
    {
        Task<IEnumerable<Model>> GetModels();
        Task<IEnumerable> GetModel(int id);
        Task<Model> Create(Model model);
        Task Update(Model model);
        Task Delete(int id);
    }
}

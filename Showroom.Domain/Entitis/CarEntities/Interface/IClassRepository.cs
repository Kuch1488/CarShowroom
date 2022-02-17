namespace Showroom.Domain.Entities.Interface
{
    public interface IClassRepository
    {
        Task<IEnumerable<Class>> GetClasses();
        Task<Class> GetClass(int id);
        Task<Class> Create(Class @class);
        Task Update(Class @class);
        Task Delete(int id);
    }
}

namespace Showroom.Domain.Entities.Interface
{
    public interface IBodyRepository
    {
        Task<IEnumerable<Body>> GetBodies();
        Task<Body> GetBody(int id);
        Task<Body> Create(Body body);
        Task Update(Body body);
        Task Delete(int id);
    }
}

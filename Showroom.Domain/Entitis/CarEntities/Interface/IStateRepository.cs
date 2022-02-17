namespace Showroom.Domain.Entities.Interface
{
    public interface IStateRepository
    {
        Task<IEnumerable<State>> GetStates();
        Task<State> GetState(int id);
        Task<State> Create(State state);
        Task Update(State state);
        Task Delete(int id);
    }
}

namespace Showroom.Domain.Entities.Interface
{
    public interface IShowroomRepository
    {
        Task<IEnumerable<CarShowroom>> GetShowrooms();
        Task<CarShowroom> GetShowroom(int id);
        Task<CarShowroom> Create(CarShowroom carShowroom);
        Task Update(CarShowroom carShowroom);
        Task Delete(int id);
    }
}

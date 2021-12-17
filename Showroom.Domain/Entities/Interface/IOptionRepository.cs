namespace Showroom.Domain.Entities.Interface
{
    public interface IOptionRepository
    {
        Task<IEnumerable<Option>> GetOptions();
        Task<Option> GetOption(int id);
        Task<Option> Create(Option option);
        Task Update(Option option);
        Task Delete(int id);
    }
}

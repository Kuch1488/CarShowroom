namespace Showroom.Domain.Entities.Interface
{
    public interface IBrandRepository
    {
        Task<IEnumerable<Brand>> GetBrands();
        Task<Brand> GetBrand(int id);
        Task<Brand> Create(Brand brand);
        Task Update(Brand brand);
        Task Delete(int id);
    }
}

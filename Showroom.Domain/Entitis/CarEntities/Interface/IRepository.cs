namespace Showroom.Domain.Entitis.CarEntities.Interface
{
    public interface IRepository<TEntity> where TEntity : class
    {
        public Task Delete(TEntity entity);
        public Task<IEnumerable<TEntity>> GetAll();
        public Task<TEntity> GetById(int id);
        public Task Insert(TEntity entity);
        public Task Update(TEntity entity);
    }
}

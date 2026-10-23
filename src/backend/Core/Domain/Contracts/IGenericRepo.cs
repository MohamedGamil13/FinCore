using Domain.Entities;

namespace Domain.Contracts
{
    public interface IGenericRepo<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        //Create Item
        Task AddAsync(TEntity entity);
        //Delete
        void Delete(TEntity entity);
        //Update Item
        void UpdateAsync(TEntity entity);
        //GetById
        Task<TEntity?> GetByIdAsync(TKey id);
        //GetAll
        Task<IEnumerable<TEntity>> GetAllAsync();
    }
}

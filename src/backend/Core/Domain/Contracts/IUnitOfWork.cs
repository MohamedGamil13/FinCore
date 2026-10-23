using Domain.Entities;

namespace Domain.Contracts
{
    public interface IUnitOfWork
    {
        IGenericRepo<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : BaseEntity<TKey>;
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}

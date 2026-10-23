using Domain.Entities;
using System.Linq.Expressions;

namespace Domain.Contracts
{
    public interface ISpecification<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        Expression<Func<TEntity, bool>>? WhereExpression { get; }
        List<Expression<Func<TEntity, object>>> IncludeExpressions { get; }
        Expression<Func<TEntity, object>>? OrderByExpressions { get; }
        Expression<Func<TEntity, object>>? OrderByDescExpressions { get; }

        int Skip { get; }
        int Take { get; }
        bool IsPaginated { get; }
    }
}

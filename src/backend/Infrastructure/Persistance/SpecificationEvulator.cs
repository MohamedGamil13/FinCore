using Domain.Contracts;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace Persistence
{
    internal static class SpecificationEvaluator
    {
        public static IQueryable<TEntity> CreateQuery<TEntity, TKey>(
            IQueryable<TEntity> inputQuery,
            ISpecification<TEntity, TKey> specification) where TEntity : BaseEntity<TKey>
        {
            var query = inputQuery;


            if (specification.WhereExpression is not null)
            {
                query = query.Where(specification.WhereExpression);
            }

            if (specification.IncludeExpressions is not null && specification.IncludeExpressions.Count > 0)
            {
                query = specification.IncludeExpressions.Aggregate(query, (current, include) => current.Include(include));
            }


            if (specification.OrderByExpressions is not null)
            {
                query = query.OrderBy(specification.OrderByExpressions);
            }
            else if (specification.OrderByDescExpressions is not null)
            {
                query = query.OrderByDescending(specification.OrderByDescExpressions);
            }


            if (specification.IsPaginated)
            {
                query = query.Skip(specification.Skip).Take(specification.Take);
            }

            return query;
        }
    }
}
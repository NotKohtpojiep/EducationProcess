using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EducationProcess.DataAccess.Repositories.Interfaces
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task<TEntity> GetFirstWhereAsync(Expression<Func<TEntity, bool>> match);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> match);
        Task<TEntity[]> FindAllByWhereAsync(Expression<Func<TEntity, bool>> match);
        Task<TEntity[]> FindAllByWhereOrderedAscendingAsync(Expression<Func<TEntity, bool>> match, Expression<Func<TEntity, object>> orderBy);
        Task<TEntity[]> FindAllByWhereOrderedDescendingAsync(Expression<Func<TEntity, bool>> match, Expression<Func<TEntity, object>> orderBy);
        Task<TEntity[]> GetAllAsync();
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity[]> AddRangeAsync(ICollection<TEntity> entities, bool saveChanges = true);
        Task<TEntity[]> UpdateRangeAsync(ICollection<TEntity> entities);
        Task<TEntity> UpdateAsync(TEntity entityToUpdate);
        Task DeleteAsync(TEntity entity);
        Task DeleteRangeAsync(ICollection<TEntity> entities);
        Task<int> Count();
    }
}
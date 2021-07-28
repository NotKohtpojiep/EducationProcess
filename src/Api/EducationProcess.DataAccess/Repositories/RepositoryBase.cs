using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EducationProcess.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace EducationProcess.DataAccess.Repositories
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly EducationProcessContext _context;

        private readonly DbSet<TEntity> _dbSet;

        protected RepositoryBase(EducationProcessContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public virtual async Task<TEntity> GetFirstWhereAsync(Expression<Func<TEntity, bool>> match)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(match);
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> match)
        {
            return await _context.Set<TEntity>().AnyAsync(match);
        }

        public virtual async Task<TEntity[]> GetAllAsync()
        {
            return await _context.Set<TEntity>().AsNoTracking().ToArrayAsync();
        }

        public async Task<TEntity[]> FindAllByWhereAsync(Expression<Func<TEntity, bool>> match)
        {
            return await _context.Set<TEntity>().Where(match).ToArrayAsync();
        }

        public async Task<TEntity[]> FindAllByWhereOrderedAscendingAsync(
            Expression<Func<TEntity, bool>> match,
            Expression<Func<TEntity, object>> orderBy)
        {
            return await _context.Set<TEntity>().Where(match).OrderBy(orderBy).ToArrayAsync();
        }

        public async Task<TEntity[]> FindAllByWhereOrderedDescendingAsync(
            Expression<Func<TEntity, bool>> match,
            Expression<Func<TEntity, object>> orderBy)
        {
            return await _context.Set<TEntity>().Where(match).OrderByDescending(orderBy).ToArrayAsync();
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public virtual async Task<TEntity[]> AddRangeAsync(ICollection<TEntity> entities, bool saveChanges = true)
        {
            await _context.Set<TEntity>().AddRangeAsync(entities);
            if (saveChanges)
            {
                await _context.SaveChangesAsync();
            }

            return entities.ToArray();
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entityToUpdate)
        {
            if (_context.Entry(entityToUpdate).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToUpdate);
            }

            _context.Entry(entityToUpdate).State = EntityState.Modified;
            _context.ChangeTracker.AutoDetectChangesEnabled = false;
            await _context.SaveChangesAsync();

            return entityToUpdate;
        }

        public virtual async Task<TEntity[]> UpdateRangeAsync(ICollection<TEntity> entities)
        {
            var detachedEntities = new List<TEntity>();
            _context.ChangeTracker.AutoDetectChangesEnabled = false;
            foreach (var entity in entities)
            {
                if (_context.Entry(entity).State == EntityState.Detached)
                {
                    detachedEntities.Add(entity);
                }

                _context.Entry(entity).State = EntityState.Modified;
            }

            _dbSet.AttachRange(detachedEntities);
            await _context.SaveChangesAsync();
            _context.ChangeTracker.AutoDetectChangesEnabled = true;

            return entities.ToArray();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRangeAsync(ICollection<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
            await _context.SaveChangesAsync();
        }

        public async Task<int> Count()
        {
            return await _context.Set<TEntity>().CountAsync();
        }
    }
}

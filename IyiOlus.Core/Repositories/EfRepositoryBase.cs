using IyiOlus.Core.Repositories.Pagination;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Core.Repositories
{
    public class EfRepositoryBase<TEntity, TId, TContext> : IAsyncRepository<TEntity, TId>
        where TEntity : Entity<TId>
        where TContext : DbContext
    {

        protected readonly TContext context;

        public EfRepositoryBase(TContext context)
        {
            this.context = context;
        }

        public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            await context.Set<TEntity>().AddAsync(entity, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public async Task<ICollection<TEntity>> AddRangeAsync(ICollection<TEntity> entities, CancellationToken cancellationToken = default)
        {
            await context.Set<TEntity>().AddRangeAsync(entities, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            return entities;
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>>? predicate = null, bool WithDeleted = false, bool enableTracking = true, CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> queryable = context.Set<TEntity>();

            if (!enableTracking)
                queryable = queryable.AsNoTracking();

            if (!WithDeleted)
                queryable = queryable.Where(x => x.DeletedDate == null);

            if (predicate != null)
                queryable = queryable.Where(predicate);

            return await queryable.AnyAsync(cancellationToken);
        }

        public async Task<TEntity> DeleteAsync(TEntity entity, bool permanent = false, CancellationToken cancellationToken = default)
        {
            if (!permanent)
            {
                entity.DeletedDate = DateTime.UtcNow;
                context.Set<TEntity>().Update(entity);
            }
            else
            {
                context.Set<TEntity>().Remove(entity);
            }

            await context.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public async Task<ICollection<TEntity>> DeleteRangeAsync(ICollection<TEntity> entities, bool permanent = false, CancellationToken cancellationToken = default)
        {
            if(!permanent)
            {
                foreach(var entity in entities)
                {
                    entity.DeletedDate = DateTime.UtcNow; 
                }
                context.Set<TEntity>().UpdateRange(entities);
            }
            else
            {
                context.Set<TEntity>().RemoveRange(entities);
            }
            await context.SaveChangesAsync(cancellationToken);
            return entities;
        }

        public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, bool withDeleted = false, bool enableTracking = true, CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> queryable = context.Set<TEntity>();

            if (!enableTracking)
                queryable = queryable.AsNoTracking();

            if (!withDeleted)
                queryable = queryable.Where(x => x.DeletedDate == null);

            if(include != null)
                queryable = include(queryable);

            return await queryable.FirstOrDefaultAsync(predicate, cancellationToken);
        }

        public async Task<int> GetCountAsync(Expression<Func<TEntity, bool>>? predicate = null, bool WithDeleted = false, bool enableTracking = true, CancellationToken cancellation = default)
        {
            IQueryable<TEntity> queryable = context.Set<TEntity>();

            if (!enableTracking)
                queryable = queryable.AsNoTracking();

            if (!WithDeleted)
                queryable = queryable.Where(x => x.DeletedDate == null);

            if (predicate != null)
                queryable = queryable.Where(predicate);

            return await queryable.CountAsync(cancellation);
        }

        public async Task<Paginate<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, int index = 0, int size = 10, bool withDeleted = false, bool enableTracking = true, CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> queryable = context.Set<TEntity>();

            if (!enableTracking)
                queryable = queryable.AsNoTracking();
            if (!withDeleted)
                queryable = queryable.Where(x => x.DeletedDate == null);
            if (include != null)
                queryable = include(queryable);
            if (orderBy != null)
                queryable = orderBy(queryable);
            if (predicate != null)
                queryable = queryable.Where(predicate);

            var totalItems = await queryable.CountAsync(cancellationToken);
            var items = await queryable.Skip(index * size).Take(size).ToListAsync(cancellationToken);

            return new Paginate<TEntity>
            { 
                Items = items,
                PageNumber = index + 1,
                PageSize = size,
                TotalItems = totalItems,
                TotalPages = (int)Math.Ceiling(totalItems / (double)size)
            };
        }

        public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            entity.UpdatedDate = DateTime.UtcNow;
            context.Set<TEntity>().Update(entity);
            await context.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public async Task<ICollection<TEntity>> UpdateRangeAsync(ICollection<TEntity> entities, CancellationToken cancellationToken = default)
        {
            foreach (var entity in entities)
            {
                entity.UpdatedDate = DateTime.UtcNow;
            }
            context.Set<TEntity>().UpdateRange(entities);
            await context.SaveChangesAsync(cancellationToken);
            return entities;
        }
    }
}

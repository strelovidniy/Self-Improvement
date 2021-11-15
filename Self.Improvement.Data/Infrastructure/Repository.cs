using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Self.Improvement.Data.Context;
using Self.Improvement.Data.Entities;

namespace Self.Improvement.Data.Infrastructure
{
    public sealed class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity
    {
        private readonly SelfImprovementContext _context;
        private readonly DbSet<TEntity> _dbEntities;

        public Repository(SelfImprovementContext context)
        {
            _context = context;
            _dbEntities = _context.Set<TEntity>();
        }

        /// <summary>
        /// Gets all entity records with included entities
        /// </summary>
        /// <param name="includes">included entities</param>
        /// <returns>IQueryable of all entity records with included entities, if includes is null this function is equal GetAll</returns>
        public IQueryable<TEntity> Query(params Expression<Func<TEntity, object>>[] includes)
        {
            var dbSet = _context.Set<TEntity>();
            var query = includes
                .Aggregate<Expression<Func<TEntity, object>>, IQueryable<TEntity>>(dbSet, (current, include) => current.Include(include));

            return query ?? dbSet;
        }

        /// <summary>
        /// Gets entity by the keys.
        /// </summary>
        /// <param name="keys">Keys for the search.</param>
        /// <returns>Entity with such keys.</returns>
        public ValueTask<TEntity> GetByIdAsync(params object[] keys) => _dbEntities.FindAsync(keys);

        /// <summary>
        /// Async add entity into DBContext
        /// </summary>
        /// <param name="entity">entity</param>
        /// <exception cref="ArgumentNullException">The entity to add cannot be <see langword="null"/>.</exception>
        /// <returns>added entity</returns>
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            CheckEntityForNull(entity);
            return (await _dbEntities.AddAsync(entity)).Entity;
        }

        /// <summary>
        /// Adds a range of entities.
        /// </summary>
        /// <param name="entities">Entities to add.</param>
        /// <returns>Task.</returns>
        public Task AddRangeAsync(IEnumerable<TEntity> entities) => _dbEntities.AddRangeAsync(entities);

        /// <summary>
        /// Updates entity asynchronously
        /// </summary>
        /// <param name="entity">entity</param>
        /// <returns>awaitable task with updated entity</returns>
        public async Task<TEntity> UpdateAsync(TEntity entity) =>
            await Task.Run(() => _dbEntities.Update(entity).Entity);

        /// <summary>
        /// Deletes range.
        /// </summary>
        /// <param name="entities">Entities to delete.</param>
        /// <returns>Task.</returns>
        public async Task DeleteRangeAsync(IEnumerable<TEntity> entities) =>
            await Task.Run(() => entities.ToList().ForEach(item => _context.Entry(item).State = EntityState.Deleted));

        /// <summary>
        /// Saves changes in the database asynchronously.
        /// </summary>
        /// <returns>Task</returns>
        public Task<int> SaveChangesAsync() => _context.SaveChangesAsync();

        /// <summary>
        /// Removes entity from DBContext
        /// </summary>
        /// <param name="entity">entity</param>
        public void Delete(TEntity entity) => _context.Entry(entity).State = EntityState.Deleted;

        /// <summary>
        /// Detaches entity
        /// </summary>
        /// <param name="entity">entity</param>
        public void Detach(TEntity entity) => _context.Entry(entity).State = EntityState.Detached;

        private static void CheckEntityForNull(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "The entity to add cannot be null.");
            }
        }
    }
}

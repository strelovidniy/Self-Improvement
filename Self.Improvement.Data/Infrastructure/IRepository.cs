﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Self.Improvement.Data.Infrastructure
{
    public interface IRepository<TEntity>
    {
        IQueryable<TEntity> Query(params Expression<Func<TEntity, object>>[] includes);

        Task<TEntity> AddAsync(TEntity entity);

        Task AddRangeAsync(IEnumerable<TEntity> entities);

        Task<bool> DeleteAsync(TEntity entity);

        Task DeleteRangeAsync(IEnumerable<TEntity> entities);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task<int> SaveChangesAsync();

        ValueTask<TEntity> GetByIdAsync(params object[] keys);
    }
}

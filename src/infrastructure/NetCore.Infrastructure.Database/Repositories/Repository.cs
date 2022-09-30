﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using NetCore.Infrastructure.Database.Commons;

namespace NetCore.Infrastructure.Database.Repositories;

public class Repository<TEntity> : IRepository<TEntity>, IDisposable where TEntity : BaseEntity
{
    private readonly DatabaseContext _databaseContext;

    public IQueryable<TEntity> Collection => _databaseContext.Set<TEntity>().AsQueryable();

    public Repository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public async Task<EntityEntry<TEntity>> AddAsync(TEntity entity)
    {
        return await _databaseContext.Set<TEntity>().AddAsync(entity);
    }

    public async Task AddRangeAsync(IEnumerable<TEntity> entities)
    {
        await _databaseContext.Set<TEntity>().AddRangeAsync(entities);
    }

    public EntityEntry<TEntity> Remove(TEntity entity)
    {
        return _databaseContext.Set<TEntity>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<TEntity> entities)
    {
        _databaseContext.Set<TEntity>().RemoveRange(entities);
    }

    public Task<IReadOnlyList<TEntity>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<TEntity> GetByIdAsync(Guid id)
    {
        return await _databaseContext.Set<TEntity>().FindAsync(id);
    }

    public EntityEntry<TEntity> Update(TEntity entity)
    {
        return _databaseContext.Set<TEntity>().Update(entity);
    }

    public void UpdateRange(IEnumerable<TEntity> entities)
    {
        _databaseContext.Set<TEntity>().UpdateRange(entities);
    }

    public int SaveChanges()
    {
        return _databaseContext.SaveChanges();
    }

    public async Task<int> SaveChangesAsync()
    {            
        return await _databaseContext.SaveChangesAsync();
    }

    public async Task<bool> ExistAsync(Expression<Func<TEntity, bool>> expression)
    {
        return await _databaseContext.Set<TEntity>().AnyAsync(expression);
    }

    private bool disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                _databaseContext.Dispose();
            }
        }
        this.disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}

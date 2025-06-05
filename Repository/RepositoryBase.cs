using api.Data;
using api.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace api.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly DataContext DataContext;

        public RepositoryBase(DataContext dataContext) => DataContext = dataContext;

        public IQueryable<T> FindAll(bool trackChanges) =>
            !trackChanges ? DataContext.Set<T>().AsNoTracking() : DataContext.Set<T>();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) =>
            !trackChanges ? DataContext.Set<T>().Where(expression).AsNoTracking() : DataContext.Set<T>().Where(expression);

        public void Create(T entity) => DataContext.Set<T>().Add(entity);
        public void Update(T entity) => DataContext.Set<T>().Update(entity);
        public void Delete(T entity) => DataContext.Set<T>().Remove(entity);

        public async Task AddAsync(T entity) =>
            await DataContext.Set<T>().AddAsync(entity);

        public async Task<IEnumerable<T>> GetAllAsync(bool trackChanges) =>
            await FindAll(trackChanges).ToListAsync();

        public async Task<T?> GetByIdAsync(int id, bool trackChanges) =>
            await DataContext.Set<T>().FindAsync(id);

        public async Task AddBulkAsync(List<T> entities) =>
            await DataContext.Set<T>().AddRangeAsync(entities);

        public void UpdateBulk(List<T> entities) =>
            DataContext.Set<T>().UpdateRange(entities);

        public async Task<bool> SaveChangesAsync() =>
            await DataContext.SaveChangesAsync(CancellationToken.None) > 0;
    }
}

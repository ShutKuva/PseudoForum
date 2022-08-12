using Core.BaseEntities;
using DAL.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DAL
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly DbContext _dbContext;

        public GenericRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(T entity)
        {
            _dbContext.Set<T>().Add(entity);

            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            T entity = await Get(id) ?? throw new ArgumentException($"{typeof(T).Name} does not exist");

            _dbContext.Set<T>().Remove(entity);

            await _dbContext.SaveChangesAsync();
        }

        public async Task Edit(T updatedEntity)
        {
            T entity = await Get(updatedEntity.Id) ?? throw new ArgumentException($"{typeof(T).Name} does not exist");

            _dbContext.Entry(entity).CurrentValues.SetValues(updatedEntity);

            await _dbContext.SaveChangesAsync();
        }

        public virtual Task<T> Get(int id)
        {
            return Task.Run(() => _dbContext.Set<T>()
                .FirstOrDefault(entity => entity.Id == id));
        }

        public virtual Task<IEnumerable<T>> GetAll()
        {
            return Task.Run(() => _dbContext.Set<T>().AsEnumerable());
        }

        public virtual Task<IQueryable<T>> GetByCondition(Expression<Func<T, bool>> condition)
        {
            return Task.Run(() => _dbContext.Set<T>().Where(condition));
        }
    }
}

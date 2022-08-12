using Core.BaseEntities;
using System.Linq.Expressions;

namespace DAL.Abstractions
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task Create(T entity);

        Task<T> Get(int id);

        Task<IEnumerable<T>> GetAll();

        Task<IQueryable<T>> GetByCondition(Expression<Func<T, bool>> condition);

        Task Edit(T updatedEntity);

        Task Delete(int id);
    }
}

using Core.BaseEntities;

namespace BLL.Abstractions
{
    public interface ICRUDService<T> where T : BaseEntity
    {
        Task Create(T entity);
        Task<T> Get(int id);
        Task<IEnumerable<T>> GetAll();
        Task Edit(T updatedEntity);
        Task Delete(int id);
    }
}

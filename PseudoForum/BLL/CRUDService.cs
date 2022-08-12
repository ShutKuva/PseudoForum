using BLL.Abstractions;
using Core.BaseEntities;
using DAL.Abstractions;

namespace BLL
{
    public class CRUDService<T> : ICRUDService<T> where T : BaseEntity
    {
        protected readonly IRepository<T> _repository;

        public CRUDService(IRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual Task Create(T entity)
        {
            return _repository.Create(entity);
        }

        public virtual Task Delete(int id)
        {
            return _repository.Delete(id);
        }

        public virtual Task Edit(T updatedEntity)
        {
            return _repository.Edit(updatedEntity);
        }

        public virtual Task<T> Get(int id)
        {
            return _repository.Get(id);
        }

        public Task<IEnumerable<T>> GetAll()
        {
            return _repository.GetAll();
        }
    }
}

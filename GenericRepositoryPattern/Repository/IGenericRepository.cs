using GenericRepositoryPattern.Models;

namespace GenericRepositoryPattern.Repository
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        public Task<IEnumerable<T>> getAll();
        public Task<T> getSingle(int id);
        public Task<int> addNew(T entity);
        public Task<int> updateNew(T entity);
        public Task<int> deleteNew(int id);
    }                  
}

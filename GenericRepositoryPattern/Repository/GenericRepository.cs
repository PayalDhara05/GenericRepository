using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using GenericRepositoryPattern.AppCode;
using GenericRepositoryPattern.Models;

namespace GenericRepositoryPattern.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly MyDbContext _myDbContext;
        private readonly DbSet<T> _myDbSet;

        public GenericRepository(MyDbContext myDbContext)
        {
            _myDbSet = myDbContext.Set<T>();
            _myDbContext = myDbContext;
        }

        public async Task<int> addNew(T entity)
        {
            if (entity == null)
                return -1;

            await _myDbSet.AddAsync(entity);
            return await _myDbContext.SaveChangesAsync();
        }

        public async Task<int> deleteNew(int id)
        {
            var itemToDelete = await _myDbSet.FindAsync(id);
            if (itemToDelete == null)
                return -1;

            _myDbSet.Remove(itemToDelete);
            return await _myDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> getAll()
        {
            return await _myDbSet.ToListAsync();
        } 

        public async Task<T> getSingle(int id)
        {
            return await _myDbSet.FindAsync(id);
        }

        public async Task<int> updateNew(T entity) 
        {
            int result = -1;
            if (entity != null && entity.Id != 0)
            {
                var itemToUpdate =  await _myDbSet.FindAsync();
                if (itemToUpdate != null)
                {
                    _myDbContext.Entry(itemToUpdate).CurrentValues.SetValues(entity);
                    await _myDbContext.SaveChangesAsync();
                    result = 1;
                }
            }
            return result;
        }
    }
}

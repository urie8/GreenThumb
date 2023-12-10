using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace GreenThumb.Database
{
    internal class GreenThumbRepository<T> where T : class
    {
        private readonly GreenThumbDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GreenThumbRepository(GreenThumbDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public List<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T? GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }
        public void AddRange(IEnumerable<T> entities)
        {
            _dbSet.AddRange(entities);
        }
        public void Delete(int id)
        {
            T? entityToDelete = GetById(id);

            if (entityToDelete != null)
            {
                _dbSet.Remove(entityToDelete);
            }
        }
        public void DeleteCompositeKey(int firstId, int secondId)
        {
            T? entityToDelete = _dbSet.Find(firstId, secondId);

            if (entityToDelete != null)
            {
                _dbSet.Remove(entityToDelete);
            }
        }
    }
}

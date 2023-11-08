using Microsoft.EntityFrameworkCore;
using RentCarApp.Data.Entities;

namespace RentCarApp.Data.Entities.Repositories
{
    public class SqlRepoitory<T> : IRepository<T> where T : class, IEntity, new()
    {
        private readonly DbSet<T> _dbSet;
        private readonly DbContext _dbContext;
        private readonly Action<T> itemAddedCallback;
        private readonly Action<T> itemRemovedCallback;
        public SqlRepoitory(DbContext dbContext, Action<T> itemAddedCallback = null, Action<T> itemRemovedCallback = null)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
            this.itemAddedCallback = itemAddedCallback;
            this.itemRemovedCallback = itemRemovedCallback;
        }

        public event EventHandler<T>? ItemAdded;
        public event EventHandler<T>? ItemRemoved;

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }
        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Add(T item)
        {
            _dbSet.Add(item);
            itemAddedCallback?.Invoke(item);
            ItemAdded?.Invoke(this, item);
        }
        public void Remove(T item)
        {
            _dbSet.Remove(item);
            itemRemovedCallback?.Invoke(item);
            ItemRemoved?.Invoke(this, item);
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}

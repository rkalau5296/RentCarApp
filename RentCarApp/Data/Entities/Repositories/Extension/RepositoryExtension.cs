using RentCarApp.Data.Entities;
using RentCarApp.Data.Entities.Repositories;

namespace RentCarApp.Data.Entities.Repositories.Extension
{
    public static class RepositoryExtentions
    {
        public static void AddBatch<T>(this IRepository<T> repository, IEnumerable<T> items)
            where T : class, IEntity
        {
            foreach (var item in items)
            {
                repository.Add(item);
            }
            repository.Save();
        }

        public static void RemoveItem<T>(this IRepository<T> repository, T item)
            where T : class, IEntity
        {
            repository.Remove(item);
            repository.Save();
        }
    }
}

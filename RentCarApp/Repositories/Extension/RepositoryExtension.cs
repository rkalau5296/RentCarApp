using RentCarApp.Entities;

namespace RentCarApp.Repositories.Extension
{
    public static class RepositoryExtentions
    {
        public static void AddBatch<T>(this IRepository<T> repository, T[] items)
            where T : class, IEntity
        {
            foreach (var item in items)
            {
                repository.Add(item);
            }
            repository.Save();
        }
    }
}

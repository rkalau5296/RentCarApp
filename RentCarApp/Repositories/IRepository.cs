using RentCarApp.Entities;

namespace RentCarApp.Repositories
{
    public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T> where T : class, IEntity, new()
    {

    }
}
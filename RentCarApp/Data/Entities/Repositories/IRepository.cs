using RentCarApp.Data.Entities;

namespace RentCarApp.Data.Entities.Repositories
{
    public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T> where T : class, IEntity
    {

    }
}
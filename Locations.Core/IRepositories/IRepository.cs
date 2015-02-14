using System.Collections.Generic;

namespace Locations.Core.IRepositories
{
    public interface IRepository<T>
    {
        T Add(T entity);
        IEnumerable<T> All();
        T GetById(int id);
        void SaveChanges();
    }
}

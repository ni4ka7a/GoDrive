namespace GoDrive.Data.Common
{
    using System.Linq;

    using GoDrive.Data.Common.Models;

    public interface IDbRepository<T>
        where T : class, IDeletableEntity, IAuditInfo
    {
    }

    public interface IDbRepository<T, in TKey>
        where T : BaseModel<TKey>
    {
        IQueryable<T> All();

        IQueryable<T> AllWithDeleted();

        T GetById(TKey id);

        void Add(T entity);

        void Delete(T entity);

        void HardDelete(T entity);

        void Save();
    }
}

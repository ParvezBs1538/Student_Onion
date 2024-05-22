using OA_Data;
using System.Linq.Expressions;

namespace OA_Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        T GetById(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties);
        void SaveChanges();
    }
}

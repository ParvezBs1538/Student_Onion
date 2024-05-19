using OA_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA_Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        //void Delete(int id);
        T Details(int id);
        T GetById(int id);
        IEnumerable<T> GetAll();
        void SaveChanges();
    }
}

using Microsoft.EntityFrameworkCore;
using OA_Data;

namespace OA_Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly MyDbContext context;
        private readonly DbSet<T> entities;
        public Repository(MyDbContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        //public void Delete(int id)
        //{
        //    entities.Remove(GetById(id));
        //    context.SaveChanges();
        //}

        public void Delete(T entity)
        {
            entities.Remove(entity);
            context.SaveChanges();
        }

        public T Details(int id)
        {
            return GetById(id);
        }

        public IEnumerable<T> GetAll()
        {
            return entities.ToList();
        }

        public T GetById(int id)
        {
            return entities.SingleOrDefault(x => x.Id == id);
        }

        public void Insert(T entity)
        {
            entities.Add(entity);
            context.SaveChanges();
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            entities.Update(entity);
            context.SaveChanges();
        }
    }
}

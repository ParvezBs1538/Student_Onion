using OA_Data;
using OA_Repository;
using System.Collections.Generic;

namespace OA_Service
{
    public class StudentService : IStudentService
    {
        private readonly IRepository<Student> db;

        public StudentService(IRepository<Student> db)
        {
            this.db = db;
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return db.GetAllIncluding(s => s.Skill);
        }

        public Student GetByStudentId(int id)
        {
            return db.GetAllIncluding(s => s.Skill).SingleOrDefault(s => s.Id == id);
        }

        public void InsertStudent(Student entity)
        {
            db.Insert(entity);
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }
    }
}

using OA_Data;
using OA_Repository;
using System.Collections.Generic;

namespace OA_Service.Student_Service
{
    public class StudentService : IStudentService
    {
        private readonly IRepository<Student> db;

        public StudentService(IRepository<Student> db)
        {
            this.db = db;
        }

        public void DeleteStudent(int id)
        {
            Student student = GetByStudentId(id);
            db.Delete(student);
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

        public Student StudentDetails(int id)
        {
            return GetByStudentId(id);
        }
    }
}

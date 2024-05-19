using Microsoft.EntityFrameworkCore;
using OA_Data;
using OA_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA_Service
{
    public class StudentService : IStudentService
    {
        private IRepository<Student> db;
        private readonly MyDbContext context;
        public StudentService(IRepository<Student> db, MyDbContext context)
        {
            this.db = db;
            this.context = context;
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return context.Students.Include(s => s.Skill).ToList();
        }

        public Student GetByStudentId(int id)
        {
            return context.Students.Include(s => s.Skill).SingleOrDefault(s => s.Id == id);
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

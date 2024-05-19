using OA_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA_Service
{
    public interface IStudentService
    {
        void InsertStudent(Student entity);
        IEnumerable<Student> GetAllStudents();
        Student GetByStudentId(int id);
        void SaveChanges();
    }
}

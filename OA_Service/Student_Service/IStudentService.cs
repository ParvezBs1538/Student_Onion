﻿using OA_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA_Service.Student_Service
{
    public interface IStudentService
    {
        void UpdateStudent(Student entity);
        void DeleteStudent(int id);
        void InsertStudent(Student entity);
        IEnumerable<Student> GetAllStudents();
        Student GetByStudentId(int id);
        Student StudentDetails(int id);
        void SaveChanges();
    }
}

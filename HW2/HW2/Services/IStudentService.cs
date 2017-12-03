using HW2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HW2.Services
{
    public interface IStudentService
    {
        Students GetStudents();

        Student GetStudent(int id);

        void AddStudent(Student student);

        void RemoveStudent(int id);
    }
}

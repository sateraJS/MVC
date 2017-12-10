using HW2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HW2.Services
{
    public class StudentService: IStudentService
    {
        private readonly StudentDbContext _context;

        public StudentService(StudentDbContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            _context = context;
        }

        public Students GetStudents()
        {
            var students = new Students();
            students.List = _context.Students.ToList();
            return students;
        }

        public Student GetStudent(int id)
        {
            return _context.Students.FirstOrDefault(x => x.Id == id);
        }

        public void AddStudent(Student student)
        {
            student.Id = 0;
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public void RemoveStudent(int id)
        {
            var student = _context.Students.FirstOrDefault(x => x.Id == id);
            _context.Students.Remove(student);
            _context.SaveChanges();
        }
    }
}

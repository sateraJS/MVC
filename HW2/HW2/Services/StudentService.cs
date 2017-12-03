using HW2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HW2.Services
{
    public class StudentService: IStudentService
    {
        private readonly StartListStudents _myListStudents;

        public StudentService(StartListStudents myListStudents)
        {
            if (myListStudents == null)
                throw new ArgumentNullException(nameof(myListStudents));

            _myListStudents = myListStudents;
        }

        public Students GetStudents()
        {
            return _myListStudents.GetStudents();
        }

        public Student GetStudent(int id)
        {
            return _myListStudents.GetStudents().List.FirstOrDefault(x => x.ID == id);
        }

        public void AddStudent(Student student)
        {
            _myListStudents.AddStudent(student);
        }

        public void RemoveStudent(int id)
        {
            _myListStudents.RemoveStudent(id);
        }
    }
}

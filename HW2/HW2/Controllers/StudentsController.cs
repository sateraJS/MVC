using HW2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HW2.Controllers
{
    public class StudentsController : Controller
    {
        private static Students _myListStudents;// = new Students() { List = new Dictionary<int, Student>() { { 1, new Student() { ID = 1, Birthday = DateTime.Parse("01.01.1990"), FIO = "Иванов_Иван_Иванович" } } } };
        
        public IActionResult Index()
        {
            if (_myListStudents == null)
            {
                _myListStudents = new Students();
                _myListStudents.List = new List<Student>();
                _myListStudents.List.Add(new Student() { ID = 1, Birthday = DateTime.Parse("01.01.1990"), LastName = "Иванов", FirstName = "Иван" });
                _myListStudents.List.Add(new Student() { ID = 2, Birthday = DateTime.Parse("10.09.1992"), LastName = "Петров", FirstName = "Петр" });
                _myListStudents.List.Add(new Student() { ID = 3, Birthday = DateTime.Parse("13.08.1993"), LastName = "Сидоров", FirstName = "Илья" });
            }
            return View(_myListStudents);
        }

        [HttpGet]
        public IActionResult CreateStudent()
        {
            var student = new Student();
            return View("CreateNewStudent", student);
        }

        [HttpPost]
        public IActionResult CreateNewStudent(Student student)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                student.ID = _myListStudents.List.Max(x => x.ID) + 1;
                _myListStudents.List.Add(student);
                var newStudent = _myListStudents.List.FirstOrDefault(x => x.ID == student.ID);
                return View("GetStudentById", newStudent);
            }
            catch(Exception e)
            {
                return BadRequest(ModelState);
            }

        }

        [HttpGet]
        public IActionResult GetStudentById(int id)
        {
            var student = _myListStudents.List.Find(x => x.ID == id);
            return View("GetStudentById", student);
        }

        [HttpGet]
        public IActionResult EditStudent(int id)
        {
            var student = _myListStudents.List.Find(x => x.ID == id);
            return View("UpdateStudent", student);
        }

        [HttpPost]
        public IActionResult UpdateStudent(Student student)
        {
            if (!ModelState.IsValid)
                return EditStudent(student.ID);
            _myListStudents.List.RemoveAll(x => x.ID == student.ID);
            _myListStudents.List.Add(student);
            return View("GetStudentById", student);
        }

        [HttpGet]
        public IActionResult DeleteStudent(int id)
        {
            var student = _myListStudents.List.Find(x => x.ID == id);
            if(student != null)
            {
                _myListStudents.List.RemoveAll(x => x.ID == id);
            }
            return View("Index", _myListStudents);
        }

    }
}

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
        private static Students _myListStudents = new Students() { List = new Dictionary<int, Student>() { { 1, new Student() { ID = 1, Birthday = DateTime.Parse("01.01.1990"), FIO = "Иванов_Иван_Иванович" } } } };
        //public StudentsController()
        //{
        //    _myListStudents = new Students();
        //    _myListStudents.List = new Dictionary<int, Student>();
        //    _myListStudents.List.Add(1, new Student() { ID = 1, Birthday = DateTime.Parse("01.01.1990"), FIO = "Иванов_Иван_Иванович" });
        //}
        [HttpPost]
        public IActionResult createNewStudent([FromBody] Student student)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                //var newStudent = new Student() { ID = student.ID, Birthday = DateTime.Parse(student.Birthday.ToString()), FIO = student.FIO};
                _myListStudents.List.Add(student.ID, student);
                return Json(student);//string.Format("Студент : {0}, {1} - успешно добавлен", id, fio);
            }
            catch(Exception e)
            {
                return BadRequest(ModelState);
            }

        }

        [HttpGet]
        public IActionResult getStudentById(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (_myListStudents.List.ContainsKey(id))
                return Json(_myListStudents.List[id]);
            else
                return BadRequest(ModelState);
        }

        [HttpGet]
        public IActionResult updateStudent(int id, string fio, string birthday)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (_myListStudents.List.ContainsKey(id))
            {
                _myListStudents.List[id].Birthday = DateTime.Parse(birthday);
                _myListStudents.List[id].FIO = fio;
                return Json(_myListStudents.List[id]);
            }
            else
            {
                _myListStudents.List.Add(id, new Student() { ID = id, Birthday = DateTime.Parse(birthday), FIO = fio });
                return Json(_myListStudents.List[id]);
            }
        }

        [HttpGet]
        public IActionResult deleteStudent(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (_myListStudents.List.ContainsKey(id))
            {
                _myListStudents.List.Remove(id);
                return getAllStudents();
            }
            else
                return BadRequest(ModelState);
        }

        [HttpGet]
        public IActionResult getAllStudents()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            //var result = string.Empty;
            //foreach (var student in _myListStudents.List)
            //    result += student.Value.ToString()+"\n";
            return Json(_myListStudents);
        }
    }
}

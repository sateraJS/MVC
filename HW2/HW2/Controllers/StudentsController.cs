using HW2.Models;
using HW2.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HW2.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentService _service;

        public StudentsController(IStudentService studentService)
        {
            _service = studentService;
        }

        public IActionResult Index([FromServices]IStudentService service)
        {
            return View(service.GetStudents());
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
                student.ID = _service.GetStudents().List.Count > 0 ? _service.GetStudents().List.Max(x=>x.ID) +1 : 0;
                _service.AddStudent(student);
                var newStudent = _service.GetStudent(student.ID);
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
            var service = HttpContext.RequestServices.GetService<IStudentService>();
            var student = service.GetStudent(id);
            return View("GetStudentById", student);
        }

        [HttpGet]
        public IActionResult EditStudent(int id)
        {
            var student = _service.GetStudent(id);
            return View("UpdateStudent", student);
        }

        [HttpPost]
        public IActionResult UpdateStudent(Student student)
        {
            if (!ModelState.IsValid)
                return EditStudent(student.ID);
            var service = ActivatorUtilities.CreateInstance<StudentService>(HttpContext.RequestServices);
            service.RemoveStudent(student.ID);
            service.AddStudent(student);
            return View("GetStudentById", student);
        }

        [HttpGet]
        public IActionResult DeleteStudent(int id)
        {
            var student = _service.GetStudent(id);
            if (student != null)
            {
                _service.RemoveStudent(student.ID);
            }
            return View("Index", _service.GetStudents());
        }

    }
}

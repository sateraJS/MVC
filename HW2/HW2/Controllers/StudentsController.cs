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
        public string createNewStudent(int id, string fio, string birthday)
        {
            try
            {
                _myListStudents.List.Add(id, new Student() { ID = id, Birthday = DateTime.Parse(birthday), FIO = fio });
                return string.Format("Студент : {0}, {1} - успешно добавлен", id, fio);
            }
            catch(Exception e)
            {
                return string.Format("Студент : {0}, {1} - не удалось добавить", id, fio);
            }

        }

        public string getStudentById(int id)
        {
            if (_myListStudents.List.ContainsKey(id))
                return _myListStudents.List[id].ToString();
            else
                return string.Format("Не удалось найти студента с id={0}", id);
        }

        public string updateStudent(int id, string fio, string birthday)
        {
            if (_myListStudents.List.ContainsKey(id))
            {
                _myListStudents.List[id].Birthday = DateTime.Parse(birthday);
                _myListStudents.List[id].FIO = fio;
                return _myListStudents.List[id].ToString() + " - успешно обновлен";
            }
            else
            {
                _myListStudents.List.Add(id, new Student() { ID = id, Birthday = DateTime.Parse(birthday), FIO = fio });
                return _myListStudents.List[id].ToString() + " - успешно обновлен";
            }
        }

        public string deleteStudent(int id)
        {
            if (_myListStudents.List.ContainsKey(id))
            {
                _myListStudents.List.Remove(id);
                return string.Format("Удален студент с id={0}", id);
            }
            else
                return string.Format("Не удалось найти студента с id={0}", id);
        }

        public string getAllStudents()
        {
            var result = string.Empty;
            foreach (var student in _myListStudents.List)
                result += student.Value.ToString()+"\n";
            return result;
        }
    }
}

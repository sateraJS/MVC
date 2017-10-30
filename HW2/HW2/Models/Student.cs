using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HW2.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string FIO { get; set; }
        public DateTime Birthday { get; set; }

        public string ToString()
        {
            return string.Format("id = {0}; ФИО = {1}; Дата рождения = {2}", ID, FIO, Birthday);
        }
    }
    public class Students
    {
        public Dictionary<int, Student> List{ get; set; }
    }
}

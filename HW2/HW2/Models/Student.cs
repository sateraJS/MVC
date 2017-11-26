using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HW2.Models
{
    public class Student
    {
        //[Required]
        //[IdValidation]
        public int ID { get; set; }

        [Display(Name = "Фамилия")]
        [Required]
        [MinLength(1)]
        public string LastName { get; set; }

        [Display(Name = "Имя")]
        [Required]
        [MinLength(1)]
        public string FirstName { get; set; }

        [Display(Name = "Дата рождения")]
        public DateTime Birthday { get; set; }

        public string ToString()
        {
            return string.Format("id = {0}; ФИ = {1} {2}; Дата рождения = {3}", ID, LastName, FirstName, Birthday);
        }
    }
    public class Students
    {
        public List<Student> List{ get; set; }
    }
}

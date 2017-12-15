using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HW2.Models
{
    public class Student
    {
        //[Required]
        //[IdValidation]
        [Column("Id")]
        public int Id { get; set; }

        [Display(Name = "Фамилия")]
        [Column("LastName")]
        [Required]
        [MinLength(1)]
        [StringLength(50)]
        public string LastName { get; set; }

        [Display(Name = "Имя")]
        [Column("FirstName")]
        [Required]
        [MinLength(1)]
        public string FirstName { get; set; }

        [Column("Birthday")]
        [Display(Name = "Дата рождения")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = false)]
        public DateTime Birthday { get; set; }

        public string ToString()
        {
            return string.Format("id = {0}; ФИ = {1} {2}; Дата рождения = {3}", Id, LastName, FirstName, Birthday);
        }
    }
    public class Students
    {
        public List<Student> List{ get; set; }
    }
}

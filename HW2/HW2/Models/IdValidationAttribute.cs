using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HW2.Models
{
    public class IdValidationAttribute: ValidationAttribute
    {
        public IdValidationAttribute()
        {}

        public IdValidationAttribute(string errorMessage): base(errorMessage)
        { }
        public override bool IsValid(object value)
        {
            var id = (int?)value;
            return id.HasValue && id > 0;
        }
    }
}

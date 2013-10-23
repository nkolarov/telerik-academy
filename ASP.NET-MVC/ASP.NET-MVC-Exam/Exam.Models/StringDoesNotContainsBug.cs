using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Models
{
    public class StringDoesNotContainsBug : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string valueAsString = value as string;
            if (valueAsString == null)
            {
                return true;
            }

            return !valueAsString.ToLower().Contains("bug");
        }
    }
}

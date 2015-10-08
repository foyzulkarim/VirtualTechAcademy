using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniSystem.DataModel
{
    public partial class Student : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext context)
        {
            List<ValidationResult> validationResults = new List<ValidationResult>();
            validationResults.Add(new ValidationResult("Test"));
            return validationResults;
        }
    }
}

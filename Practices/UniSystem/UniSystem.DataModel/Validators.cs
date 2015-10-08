using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniSystem.DataModel
{
    public interface IDbValidableObject
    {
        List<DbValidationError> Validate(UniSystemDbContext dbContext);
    }

    public partial class Student : IValidatableObject, IDbValidableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext context)
        {
            List<ValidationResult> validationResults = new List<ValidationResult>();
         //   validationResults.Add(new ValidationResult("Test"));
            return validationResults;
        }

        public List<DbValidationError> Validate(UniSystemDbContext dbContext)
        {
            var validationResults = new List<DbValidationError>();

            if (dbContext.Students.FirstOrDefault(x=>x.Phone==Phone)!=null)
            {
                validationResults.Add(new DbValidationError("Phone", "Duplicate phone: " + Phone));
            }
            return validationResults;
        }
    }
}

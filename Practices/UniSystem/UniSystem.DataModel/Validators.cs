using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniSystem.DataModel
{    
    public partial class Student : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext context)
        {
            const string key = "DbContext";
            UniSystemDbContext db = context.Items.Count == 0 ? null:  context.Items.ContainsKey(key)==false ? null : context.Items[key] as UniSystemDbContext;
            if (db?.Students.FirstOrDefault(x => x.Phone == Phone) != null)
            {
                yield return new ValidationResult("Duplicate phone: " + Phone, new[] { "Phone" });
            }
        }

        
    }
}

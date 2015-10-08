using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniSystem.DataModel;

namespace UniSystem.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            UniSystemDbContext db = new UniSystemDbContext();
            Student student = new Student();
            Console.WriteLine("Enter a new student: ");
            Console.WriteLine("Name: ");
            student.Name = "te";
            Console.WriteLine("Email: ");
            student.Email = "te";
            Console.WriteLine("Phone: ");
            student.Phone = "te";
            Console.WriteLine("Address: ");
           student.Address = "te";
            ValidationContext context = new ValidationContext(student);
            List<ValidationResult> validationResults = new List<ValidationResult>();
            bool tryValidateObject = Validator.TryValidateObject(student, context, validationResults, true);
            
            db.Students.Add(student);
           
            IEnumerable<DbEntityValidationResult> dbEntityValidationResults = db.GetValidationErrors();
            int saveChanges = db.SaveChanges();
            Console.WriteLine(saveChanges);
        }
    }
}

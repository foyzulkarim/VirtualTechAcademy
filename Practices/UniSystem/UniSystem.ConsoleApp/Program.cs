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
            Department department = new Department() {Name = "CSE"};

            Student student = new Student();
            Console.WriteLine("Enter a new student: ");
            Console.WriteLine("Name: ");
            student.Name = "te";
            Console.WriteLine("Email: ");
            student.Email = "te";
            Console.WriteLine("Phone: ");
            student.Phone = DateTime.Now.Ticks.ToString();
            Console.WriteLine("Address: ");
            student.Address = "te";
            student.Department = department;

            ValidationContext context = new ValidationContext(student);
            List<ValidationResult> validationResults = new List<ValidationResult>();
            bool tryValidateObject = Validator.TryValidateObject(student, context, validationResults, true);
            if (tryValidateObject)
            {
                db.Students.Add(student);
                try
                {
                    int saveChanges = db.SaveChanges();
                    Console.WriteLine(saveChanges);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }
                Console.ReadLine();
            }
        }
    }
}

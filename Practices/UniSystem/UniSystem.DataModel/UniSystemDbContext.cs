using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniSystem.DataModel
{
    public class UniSystemDbContext : DbContext
    {
        public UniSystemDbContext():base("UniSystemDbContext")
        {
            
        }

        public DbSet<Student> Students { get; set; }

        protected override DbEntityValidationResult ValidateEntity(DbEntityEntry entityEntry, IDictionary<object, object> items)
        {
            //IDbValidableObject entity = entityEntry.Entity as IDbValidableObject;
            //var result = new DbEntityValidationResult(entityEntry, new List<DbValidationError>());
            //var validationResults = entity.Validate(this);
            //if (validationResults.Count>0)
            //{
            //    foreach (DbValidationError error in validationResults)
            //    {
            //        result.ValidationErrors.Add(error);
            //    }
            //}
            //items.Add("DbContext",this);
            //return result.ValidationErrors.Count>0 ? result : base.ValidateEntity(entityEntry, items);
            
            items.Add("DbContext", this);
            return base.ValidateEntity(entityEntry, items);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var x = modelBuilder.Configurations;
            base.OnModelCreating(modelBuilder);
        }
        
    }
}

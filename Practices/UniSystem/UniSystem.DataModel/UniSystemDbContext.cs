using System;
using System.Collections.Generic;
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
            var x = entityEntry.Entity;
            return base.ValidateEntity(entityEntry, items);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var x = modelBuilder.Configurations;
            base.OnModelCreating(modelBuilder);
        }
        
    }
}

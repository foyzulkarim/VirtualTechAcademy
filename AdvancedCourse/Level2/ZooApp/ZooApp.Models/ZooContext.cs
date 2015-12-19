using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooApp.Models
{
    public class ZooContext : DbContext
    {
        public ZooContext() : base("ZooContext")
        {
            
        }

        public DbSet<Animal> Animals { get; set; }
        public DbSet<AnimalFood> AnimalFoods { get; set; }
        public DbSet<Food> Foods { get; set; }
        
    }
}

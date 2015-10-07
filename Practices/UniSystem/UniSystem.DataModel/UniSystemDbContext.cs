using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    }
}

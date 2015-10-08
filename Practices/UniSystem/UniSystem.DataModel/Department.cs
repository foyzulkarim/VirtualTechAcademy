using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniSystem.DataModel
{
    public partial class Department : BaseEntity
    {
        [Required]
        [StringLength(50)]
        [Index("Ix_UniqueDepartmentName")]
        public string Name { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}

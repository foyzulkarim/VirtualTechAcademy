using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniSystem.DataModel.Validations;

namespace UniSystem.DataModel
{
    public partial class Student  : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(20)]
        public string Phone { get; set; }
        [Required]
        [StringLength(30)]
        [DataType(DataType.EmailAddress)]
        [Index("Ix_UniqueEmail", IsUnique = true)]
        public string Email { get; set; }
        [Required]
        [StringLength(500)]
        public string Address { get; set; }

        [Required]
        [ForeignKey("Department")]
        public Guid DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniSystem.DataModel
{
    public class Student
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(20)]
        public string Phone { get; set; }
        [Required]
        [StringLength(30)]
        [Index("Ix_UniqueEmail", IsUnique = true)]
        public string Email { get; set; }
        [Required]
        [StringLength(500)]
        public string Address { get; set; }
    }
}

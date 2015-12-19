using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooApp.Models
{
    public partial class Animal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Index("Ix_AnimalName", 1, IsUnique = true)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        [Index("Ix_AnimalOrigin")]
        public string Origin { get; set; }
        [Required]
        public int Quantity { get; set; }
        public virtual ICollection<AnimalFood> AnimalFoods { get; set; }
    }

    public partial class Animal : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {          
            ZooContext db = new ZooContext();
            Name = Name.ToUpper();
            var dbModel = db.Animals.FirstOrDefault(x => x.Name.ToUpper() == Name);
            if (dbModel!=null)
            {
                ValidationResult error = new ValidationResult("Name already exists", new[] {"Name"});
                yield return error;
            }
         
        }
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZooApp.Models
{
    public class Food
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Index("Ix_FoodName")]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }

        public virtual ICollection<AnimalFood> AnimalFoods { get; set; }
    }
}
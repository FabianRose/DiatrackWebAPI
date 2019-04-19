using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiatrackWebAPI.Model
{
    [Table("meal_types")]
    public partial class MealTypes
    {
        public MealTypes()
        {
            Meals = new HashSet<Meals>();
        }

        [Column("meal_type_id")]
        [StringLength(1)]
        public string MealTypeId { get; set; }
        [Required]
        [Column("meal_desc")]
        [StringLength(20)]
        public string MealDesc { get; set; }

        [InverseProperty("MealType")]
        public virtual ICollection<Meals> Meals { get; set; }
    }
}

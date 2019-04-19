using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiatrackWebAPI.Model
{
    [Table("meals")]
    public partial class Meals
    {
        [Column("user_id")]
        public int UserId { get; set; }
        [Column("meal_type_id")]
        [StringLength(1)]
        public string MealTypeId { get; set; }
        [Column("meal_date", TypeName = "date")]
        public DateTime MealDate { get; set; }
        [Column("meal_time")]
        public TimeSpan MealTime { get; set; }

        [ForeignKey("MealTypeId")]
        [InverseProperty("Meals")]
        public virtual MealTypes MealType { get; set; }
        [ForeignKey("UserId")]
        [InverseProperty("Meals")]
        public virtual Users User { get; set; }
    }
}

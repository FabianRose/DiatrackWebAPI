using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiatrackWebAPI.Model
{
    [Table("patient_readings")]
    public partial class PatientReadings
    {
        [Column("patient_id")]
        public int PatientId { get; set; }
        [Column("reading_type_id")]
        [StringLength(2)]
        public string ReadingTypeId { get; set; }
        [Column("reading_date", TypeName = "date")]
        public DateTime ReadingDate { get; set; }
        [Required]
        [Column("reading_value")]
        [StringLength(20)]
        public string ReadingValue { get; set; }

        [ForeignKey("PatientId")]
        [InverseProperty("PatientReadings")]
        public virtual Users Patient { get; set; }
    }
}

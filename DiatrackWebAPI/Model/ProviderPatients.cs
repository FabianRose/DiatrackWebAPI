using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiatrackWebAPI.Model
{
    [Table("provider_patients")]
    public partial class ProviderPatients
    {
        [Column("provider_id")]
        public int ProviderId { get; set; }
        [Column("patient_id")]
        public int PatientId { get; set; }

        [ForeignKey("PatientId")]
        [InverseProperty("ProviderPatients")]
        public virtual Users Patient { get; set; }
        [ForeignKey("ProviderId")]
        [InverseProperty("ProviderPatients")]
        public virtual Provider Provider { get; set; }
    }
}

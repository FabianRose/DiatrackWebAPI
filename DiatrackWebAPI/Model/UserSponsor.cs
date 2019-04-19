using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiatrackWebAPI.Model
{
    [Table("user_sponsor")]
    public partial class UserSponsor
    {
        [Column("sponsor_id")]
        public int SponsorId { get; set; }
        [Column("patient_id")]
        public int PatientId { get; set; }

        [ForeignKey("PatientId")]
        [InverseProperty("UserSponsorPatient")]
        public virtual Users Patient { get; set; }
        [ForeignKey("SponsorId")]
        [InverseProperty("UserSponsorSponsor")]
        public virtual Users Sponsor { get; set; }
    }
}

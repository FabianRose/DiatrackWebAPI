using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiatrackWebAPI.Model
{
    [Table("provider")]
    public partial class Provider
    {
        public Provider()
        {
            ProviderPatients = new HashSet<ProviderPatients>();
        }

        [Column("provider_id")]
        public int ProviderId { get; set; }
        [Required]
        [Column("firstname")]
        [StringLength(50)]
        public string Firstname { get; set; }
        [Required]
        [Column("lastname")]
        [StringLength(50)]
        public string Lastname { get; set; }
        [Required]
        [Column("street")]
        [StringLength(50)]
        public string Street { get; set; }
        [Required]
        [Column("town")]
        [StringLength(50)]
        public string Town { get; set; }
        [Required]
        [Column("parish")]
        [StringLength(50)]
        public string Parish { get; set; }
        [Required]
        [Column("country")]
        [StringLength(50)]
        public string Country { get; set; }

        [ForeignKey("ProviderId")]
        [InverseProperty("Provider")]
        public virtual Users ProviderNavigation { get; set; }
        [InverseProperty("Provider")]
        public virtual ICollection<ProviderPatients> ProviderPatients { get; set; }
    }
}

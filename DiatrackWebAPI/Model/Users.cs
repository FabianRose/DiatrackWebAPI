using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiatrackWebAPI.Model
{
    [Table("users")]
    public partial class Users
    {
        public Users()
        {
            Meals = new HashSet<Meals>();
            PatientReadings = new HashSet<PatientReadings>();
            ProviderPatients = new HashSet<ProviderPatients>();
            UserSponsorPatient = new HashSet<UserSponsor>();
            UserSponsorSponsor = new HashSet<UserSponsor>();
        }

        [Column("user_id")]
        public int UserId { get; set; }
        [Required]
        [Column("gender")]
        [StringLength(10)]
        public string Gender { get; set; }
        [Column("dob", TypeName = "date")]
        public DateTime Dob { get; set; }
        [Column("phone")]
        public long Phone { get; set; }
        [Required]
        [Column("email")]
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        [Column("password")]
        [StringLength(250)]
        public string Password { get; set; }
        [Required]
        [Column("user_type_id")]
        [StringLength(1)]
        public string UserTypeId { get; set; }
        [Column("feet")]
        public int? Feet { get; set; }
        [Column("inches")]
        public int? Inches { get; set; }

        [ForeignKey("UserTypeId")]
        [InverseProperty("Users")]
        public virtual UserTypes UserType { get; set; }
        [InverseProperty("ProviderNavigation")]
        public virtual Provider Provider { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<Meals> Meals { get; set; }
        [InverseProperty("Patient")]
        public virtual ICollection<PatientReadings> PatientReadings { get; set; }
        [InverseProperty("Patient")]
        public virtual ICollection<ProviderPatients> ProviderPatients { get; set; }
        [InverseProperty("Patient")]
        public virtual ICollection<UserSponsor> UserSponsorPatient { get; set; }
        [InverseProperty("Sponsor")]
        public virtual ICollection<UserSponsor> UserSponsorSponsor { get; set; }
    }
}

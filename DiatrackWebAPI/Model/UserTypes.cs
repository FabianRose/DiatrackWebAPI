using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiatrackWebAPI.Model
{
    [Table("user_types")]
    public partial class UserTypes
    {
        public UserTypes()
        {
            Users = new HashSet<Users>();
        }

        [Column("user_type_id")]
        [StringLength(1)]
        public string UserTypeId { get; set; }
        [Required]
        [Column("user_desc")]
        [StringLength(20)]
        public string UserDesc { get; set; }

        [InverseProperty("UserType")]
        public virtual ICollection<Users> Users { get; set; }
    }
}
